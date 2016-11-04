using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whole_Lotta_Genes {
    class DNABrush {
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

        public int a;
        public int r;
        public int g;
        public int b;

        public DNABrush() {
            calculated = false;

            a = gen.GetRandom(set.minValueAlpha, set.maxValueAlpha + 1);
            r = gen.GetRandom(set.minValueRed, set.maxValueRed + 1);
            g = gen.GetRandom(set.minValueGreen, set.maxValueGreen + 1);
            b = gen.GetRandom(set.minValueBlue, set.maxValueBlue + 1);
        }

        public DNABrush Copy() {
            DNABrush copy = new DNABrush();
            copy.IsCalculated = calculated;

            copy.a = a;
            copy.r = r;
            copy.g = g;
            copy.b = b;

            return copy;
        }

        public void Mutate() {
            if (gen.WillMutate(set.mutationChanceAlpha)) {
                a = gen.GetRandom(set.minValueAlpha, set.maxValueAlpha + 1);
                SetCalculated(false);
            }
            if (gen.WillMutate(set.mutationChanceRed)) {
                r = gen.GetRandom(set.minValueRed, set.maxValueRed + 1);
                SetCalculated(false);
            }
            if (gen.WillMutate(set.mutationChanceGreen)) {
                g = gen.GetRandom(set.minValueGreen, set.maxValueGreen + 1);
                SetCalculated(false);
            }
            if (gen.WillMutate(set.mutationChanceBlue)) {
                b = gen.GetRandom(set.minValueBlue, set.maxValueBlue + 1);
                SetCalculated(false);
            }
        }

        void SetCalculated(bool value) {
            calculated = value;
        }
    }
}
