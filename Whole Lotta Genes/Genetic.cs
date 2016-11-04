using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;

namespace Whole_Lotta_Genes {
    class Genetic {
        Settings set;
        Bitmap targetBmp;
        int[,,] bmpdata;

        DNAPicture[] population;

        public int generation;
        double maxFitness;

        public int resX;
        public int resY;

        Thread thread;
        bool paused;

        Random rand;
        public double GetRandom() {
            return rand.NextDouble();
        }
        public int GetRandom(int max) {
            return rand.Next(max);
        }
        public int GetRandom(int min, int max) {
            return rand.Next(min, max);
        }

        public Genetic(Bitmap bmp, Settings set) {
            this.set = set;
            DNAPicture.set = set;
            DNAPicture.gen = this;
            DNAPolygon.set = set;
            DNAPolygon.gen = this;
            DNAPoint.set = set;
            DNAPoint.gen = this;
            DNABrush.set = set;
            DNABrush.gen = this;

            paused = true;

            rand = new Random(set.seed);

            resX = (int)Math.Round(bmp.Width * set.scale);
            resY = (int)Math.Round(bmp.Height * set.scale);

            generation = 1;
            maxFitness = (double)resX * resY * 255 * 255 * 3;

            targetBmp = new Bitmap(bmp, new Size(resX, resY));
            bmpdata = new int[targetBmp.Height, targetBmp.Width, 3];
            for (int y = 0; y < targetBmp.Height; ++y) {
                for (int x = 0; x < targetBmp.Width; ++x) {
                    Color col = targetBmp.GetPixel(x, y);
                    bmpdata[y, x, 0] = col.B;
                    bmpdata[y, x, 1] = col.G;
                    bmpdata[y, x, 2] = col.R;
                }
            }

            population = new DNAPicture[set.populationSize];
            for (int i = 0; i < set.populationSize; ++i) {
                population[i] = new DNAPicture();

                population[i].fitness = GetFitness(population[i]);
                population[i].IsCalculated = true;
            }
            Array.Sort(population, (a, b) => b.fitness.CompareTo(a.fitness));
        }

        public void NextStep() {
            while (!paused) {
                if (set.populationSize == 1) {
                    DNAPicture copy = population[0].Copy();
                    copy.Mutate();

                    if (copy.IsCalculated == false) {
                        ++generation;

                        copy.fitness = GetFitness(copy);
                        copy.IsCalculated = true;

                        if (copy.fitness >= population[0].fitness)
                            population[0] = copy;
                    }
                } else { // Momentan nu merge daca populatia este mai mare de 1
                    int selected = Math.Max(1, (int)Math.Round(set.populationSize * set.selectedAmount));
                    for (int i = selected; i < set.populationSize; ++i) {
                        int ind1 = rand.Next(selected);
                        int ind2 = rand.Next(selected);
                        //while (ind1 == ind2)
                        //    ind2 = rand.Next(selected);

                        population[i] = new DNAPicture(population[ind1], population[ind2]);
                        population[i].Mutate();

                        population[i].fitness = GetFitness(population[i]);
                        population[i].IsCalculated = true;
                    }
                    for (int i = 0; i < selected; ++i) {
                        DNAPicture copy = population[i].Copy();
                        copy.Mutate();
                        if (copy.IsCalculated == false) {
                            copy.fitness = GetFitness(copy);
                            copy.IsCalculated = true;

                            if (copy.fitness >= population[0].fitness)
                                population[i] = copy;
                        }
                     }

                    Array.Sort(population, (a, b) => b.fitness.CompareTo(a.fitness));

                    ++generation;
                }
            }
        }

        public DNAPicture GetIndividual(int ind) {
            return population[ind];
        }

        public double GetFitness(DNAPicture ind) {
            Bitmap bmp = ind.GenerateBitmap(resX, resY);
            double fit = Deviation(bmp);
            return 100 - fit * 100 / maxFitness;
        }

        public double Deviation(Bitmap bmp1) {
            double dif = 0;
            unsafe
            {
                BitmapData data1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadWrite, bmp1.PixelFormat);
                int bytesPerPixel = Image.GetPixelFormatSize(bmp1.PixelFormat) / 8;
                int height = data1.Height;
                int width = data1.Width * bytesPerPixel;
                byte* ptr1 = (byte*)data1.Scan0;

                for (int y = 0; y < height; ++y) {
                    byte* line1 = ptr1 + (y * data1.Stride);
                    for (int x = 0; x < width; x += bytesPerPixel) {
                        dif += (line1[x] - bmpdata[y, x / bytesPerPixel, 0]) * (line1[x] - bmpdata[y, x / bytesPerPixel, 0]);
                        dif += (line1[x + 1] - bmpdata[y, x / bytesPerPixel, 1]) * (line1[x + 1] - bmpdata[y, x / bytesPerPixel, 1]);
                        dif += (line1[x + 2] - bmpdata[y, x / bytesPerPixel, 2]) * (line1[x + 2] - bmpdata[y, x / bytesPerPixel, 2]);
                    }
                }
                bmp1.UnlockBits(data1);
            }
            return dif;
        }

        public bool WillMutate(int chance) {
            return GetRandom(chance) == 0;
        }

        public void Start() {
            if (paused == true) {
                paused = false;

                if (thread != null)
                    KillThread();
                thread = new Thread(NextStep);
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.AboveNormal;
                thread.Start();
            }
        }

        public void Pause() {
            if (paused == false) {
                paused = true;

                KillThread();
            }
        }

        void KillThread() {
            if (thread != null)
                thread.Abort();
            thread = null;
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whole_Lotta_Genes {
    class Genetic {
        public Individual[] population;
        Settings set;
        Bitmap targetBmp;
        int[,,] bmpdata;

        public int generation;
        double maxFitness;

        public int resX;
        public int resY;

        Random rand;
        public double GetRandom() {
            return rand.NextDouble();
        }
        public int GetRandom(int max) {
            return rand.Next(max);
        }

        public Genetic(Bitmap bmp, Settings set) {
            this.set = set;
            Individual.set = set;
            Individual.gen = this;
            DNAPolygon.set = set;
            DNAPolygon.gen = this;
            DNAPoint.set = set;
            DNAPoint.gen = this;
            DNABrush.set = set;
            DNABrush.gen = this;

            rand = new Random(set.seed);

            resX = (int)Math.Round(bmp.Width * set.scale);
            resY = (int)Math.Round(bmp.Height * set.scale);

            generation = 1;
            maxFitness = (double)resX * resY * 255 * 255 * 3;

            targetBmp = new Bitmap(bmp, new Size(resX, resY));
            bmpdata = new int[targetBmp.Height, targetBmp.Width, 3];
            for (int y = 0; y < targetBmp.Height; ++y) {
                for (int x = 0; x < targetBmp.Width; ++x) {
                    Color col = targetBmp.GetPixel(x, y);
                    bmpdata[y, x, 0] = col.B;
                    bmpdata[y, x, 1] = col.G;
                    bmpdata[y, x, 2] = col.R;
                }
            }

            population = new Individual[set.populationSize];
            for (int i = 0; i < set.populationSize; ++i) {
                population[i] = new Individual();
                population[i].fitness = GetFitness(population[i]);
                population[i].IsCalculated = true;
            }
            Array.Sort(population, (a, b) => b.fitness.CompareTo(a.fitness));
        }

        public void NextStep() {
            if (set.populationSize == 1) {
                Individual copy = population[0].Copy();
                copy.Mutate();
                if (copy.IsCalculated == false) {
                    ++generation;
                    copy.fitness = GetFitness(copy);
                    copy.IsCalculated = true;
                    if (copy.fitness > population[0].fitness)
                        population[0] = copy;
                }
                
            } else {
                List<Individual> newGenetation = new List<Individual>();
                int selected = (int)Math.Floor(set.populationSize * set.selectedAmount);

                for (int i = selected; i < set.populationSize; ++i) {
                    int ind1 = rand.Next(selected);
                    int ind2 = rand.Next(selected);
                    while (ind1 == ind2)
                        ind2 = rand.Next(selected);
                    population[i] = new Individual(population[ind1], population[ind2]);
                }
                Array.Sort(population, (a, b) => b.fitness.CompareTo(a.fitness));
            }
            
        }

        public Individual GetIndividual(int ind) {
            if (ind >= set.populationSize)
                return population[set.populationSize - 1];
            else
                return population[ind];
        }

        public double GetFitness(Individual ind) {
            Bitmap bmp = ind.GenerateBitmap(resX, resY);
            double fit = Deviation(bmp);
            return 100 - fit * 100 / maxFitness;
        }
        
        public double Deviation(Bitmap bmp1) {
            double dif = 0;
            unsafe
            {
                BitmapData data1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadWrite, bmp1.PixelFormat);
                int bytesPerPixel = Image.GetPixelFormatSize(bmp1.PixelFormat) / 8;
                int height = data1.Height;
                int width = data1.Width * bytesPerPixel;
                byte* ptr1 = (byte*)data1.Scan0;

                for (int y = 0; y < height; ++y) {
                    byte* line1 = ptr1 + (y * data1.Stride);
                    for (int x = 0; x < width; x += bytesPerPixel) {
                        dif += (line1[x] - bmpdata[y, x / bytesPerPixel, 0]) * (line1[x] - bmpdata[y, x / bytesPerPixel, 0]);
                        dif += (line1[x + 1] - bmpdata[y, x / bytesPerPixel, 1]) * (line1[x + 1] - bmpdata[y, x / bytesPerPixel, 1]);
                        dif += (line1[x + 2] - bmpdata[y, x / bytesPerPixel, 2]) * (line1[x + 2] - bmpdata[y, x / bytesPerPixel, 2]);
                    }
                }
                bmp1.UnlockBits(data1);
            }
            return dif;
        }

        public bool WillMutate(int chance) {
            return GetRandom(chance) == 0;
        }
    }
}*/