using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whole_Lotta_Genes {
    class DNAPoint {
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

        public double x;
        public double y;

        public DNAPoint() {
            calculated = false;

            x = gen.GetRandom();
            y = gen.GetRandom();
        }

        public DNAPoint Copy() {
            DNAPoint copy = new DNAPoint();
            copy.calculated = calculated;

            copy.x = x;
            copy.y = y;

            return copy;
        }

        public void Mutate() {
            if (gen.GetRandom(set.mutationChancePointMax) == 0) {
                x = gen.GetRandom();
                y = gen.GetRandom();
                SetCalculated(false);
            }

            if (gen.WillMutate(set.mutationChancePointMed)) {
                x = Math.Max(0,
                    Math.Min(1, x + 2 * (gen.GetRandom() - 0.5) * set.mutationAmountPointMed));
                y = Math.Max(0,
                    Math.Min(1, y + 2 * (gen.GetRandom() - 0.5) * set.mutationAmountPointMed));
                SetCalculated(false);
            }

            if (gen.WillMutate(set.mutationChancePointMin)) {
                x = Math.Max(0,
                    Math.Min(1, x + 2 * (gen.GetRandom() - 0.5) * set.mutationAmountPointMin));
                y = Math.Max(0,
                    Math.Min(1, y + 2 * (gen.GetRandom() - 0.5) * set.mutationAmountPointMin));
                SetCalculated(false);
            }
        }

        void SetCalculated(bool value) {
            calculated = value;
        }
    }
}
