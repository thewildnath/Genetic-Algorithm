using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whole_Lotta_Genes {
    class DNAPicture {
        public static Settings set;
        public static Genetic gen;

        bool calculated;
        public bool IsCalculated {
            get {
                return calculated;
            }
            set {
                SetCalculated(value);
            }
        }

        public List<DNAPolygon> polygons;

        public double fitness;

        public DNAPicture() {
            calculated = false;
            fitness = 0;

            polygons = new List<DNAPolygon>();
            for (int i = 0; i < set.polygonCountMin; ++i)
                polygons.Add(new DNAPolygon());
        }

        public DNAPicture(DNAPicture mother, DNAPicture father) {
            calculated = false;
            fitness = 0;

            polygons = new List<DNAPolygon>();

            int i = mother.polygons.Count - 1;
            int j = father.polygons.Count - 1;
            while (i >= 0 || j >= 0) {
                if (i >= 0 && j >= 0) {
                    if (gen.GetRandom() < 0.5)
                        polygons.Add(mother.polygons[i]);
                    else
                        polygons.Add(father.polygons[j]);
                } else if (i >= 0)
                    polygons.Add(mother.polygons[i]);
                else
                    polygons.Add(father.polygons[j]);
                --i;
                --j;
            }

            polygons.Reverse();
        }

        public DNAPicture Copy() {
            DNAPicture copy = new DNAPicture();

            copy.polygons.Clear();
            copy.IsCalculated = calculated;
            copy.fitness = fitness;

            for (int i = 0; i < polygons.Count; ++i)
                copy.polygons.Add(polygons[i].Copy());

            return copy;
        }

        public void Mutate() {
            if (gen.WillMutate(set.mutationChanceAddPolygon) && polygons.Count < set.polygonCountMax) {
                int ind = gen.GetRandom(polygons.Count);
                polygons.Insert(ind, new DNAPolygon());
                SetCalculated(false);
            }

            if (gen.WillMutate(set.mutationChanceRemovePolygon) && polygons.Count > set.polygonCountMin) {
                int ind = gen.GetRandom(polygons.Count);
                polygons.RemoveAt(ind);
                SetCalculated(false);
            }

            if (gen.WillMutate(set.mutationChanceMovePolygon) && polygons.Count > 0) {
                int ind = gen.GetRandom(polygons.Count);
                polygons.RemoveAt(ind);
                ind = gen.GetRandom(polygons.Count);
                polygons.Insert(ind, new DNAPolygon());
                SetCalculated(false);
            }

            for (int i = 0; i < polygons.Count; ++i) {
                polygons[i].Mutate();
                if (polygons[i].IsCalculated == false)
                    SetCalculated(false);
            }
        }

        void SetCalculated(bool value) {
            calculated = value;
            if (value == true) {
                for (int i = 0; i < polygons.Count; ++i)
                    polygons[i].IsCalculated = true;
            }
        }

        public Bitmap GenerateBitmap(int resX, int resY) {
            Bitmap bmp = new Bitmap(resX, resY);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.Black);
            double radius = Math.Sqrt(resX * resX + resY * resY) / 2;

            for (int i = 0; i < polygons.Count; ++i) {
                //int a = (int)Math.Round(polygons[i].brush.a * 255);
                //int r = (int)Math.Round(polygons[i].dna[1] * 255);
                //int g = (int)Math.Round(polygons[i].dna[2] * 255);
                //int b = (int)Math.Round(polygons[i].dna[3] * 255);
                int a = polygons[i].brush.a;
                int r = polygons[i].brush.r;
                int g = polygons[i].brush.g;
                int b = polygons[i].brush.b;
                SolidBrush brush = new SolidBrush(Color.FromArgb(a, r, g, b));

                PointF[] points = new PointF[polygons[i].points.Count];
                for (int j = 0; j < points.Length; ++j) {
                    int x = (int)Math.Round(polygons[i].points[j].x * resX);
                    int y = (int)Math.Round(polygons[i].points[j].y * resY);
                    points[j] = new PointF(x, y);
                }
                graphics.FillPolygon(brush, points);
            }
            return bmp;
        }
    }
}