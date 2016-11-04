using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whole_Lotta_Genes {
    class DNAPolygon {
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

        public DNABrush brush;
        public List<DNAPoint> points;

        public DNAPolygon() {
            brush = new DNABrush();
            points = new List<DNAPoint>();

            calculated = false;
            
            double x = gen.GetRandom();
            double y = gen.GetRandom();

            for (int i = 0; i < set.pointCountMin; ++i) {
                DNAPoint point = new DNAPoint();
                point.x = Math.Max(0,
                    Math.Min(1, x + 2 * (gen.GetRandom() - 0.5) * set.polygonInitialScale));
                point.y = Math.Max(0,
                    Math.Min(1, y + 2 * (gen.GetRandom() - 0.5) * set.polygonInitialScale));
                points.Add(point);
            }
        }

        public DNAPolygon Copy() {
            DNAPolygon copy = new DNAPolygon();
            copy.brush = brush.Copy();
            copy.points.Clear();

            copy.IsCalculated = calculated;

            for (int i = 0; i < points.Count; ++i)
                copy.points.Add(points[i].Copy());

            return copy;
        }

        public void Mutate() {
            if (gen.WillMutate(set.mutationChanceAddPoint) && points.Count < set.pointCountMax) {
                int ind = 1 + gen.GetRandom(points.Count);

                DNAPoint prev = points[ind - 1];
                DNAPoint next = points[ind % points.Count];

                DNAPoint newPoint = new DNAPoint();
                newPoint.x = (prev.x + next.x) / 2;
                newPoint.y = (prev.y + next.y) / 2;

                points.Insert(ind, newPoint);
                SetCalculated(false);
            }

            if (gen.WillMutate(set.mutationChanceRemovePoint) && points.Count > set.pointCountMin) {
                int ind = gen.GetRandom(points.Count);
                points.RemoveAt(ind);
                SetCalculated(false);
            }

            for (int i = 0; i < points.Count; ++i) {
                points[i].Mutate();
                if (points[i].IsCalculated == false)
                    SetCalculated(false);
            }

            brush.Mutate();
            if (brush.IsCalculated == false)
                SetCalculated(false);
        }

        void SetCalculated(bool value) {
            calculated = value;
            if (value == true) {
                brush.IsCalculated = true;

                for (int i = 0; i < points.Count; ++i)
                    points[i].IsCalculated = true;
            }
        }
    }
}