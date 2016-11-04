using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whole_Lotta_Genes {
    class Settings {
        public bool useParallel; // not implemented yet
        public int seed; // doesn't work when useParallel is true

        public double scale;

        public int populationSize;
        public double selectedAmount;
        
        public bool fittestSurvive;

        public int mutationChanceAddPolygon;
        public int mutationChanceRemovePolygon;
        public int mutationChanceMovePolygon;

        public int polygonCountMin;
        public int polygonCountMax;
        public double polygonInitialScale;

        public int mutationChanceAddPoint;
        public int mutationChanceRemovePoint;
        public int mutationChancePointMin;
        public int mutationChancePointMed;
        public int mutationChancePointMax;

        public int pointCountMin;
        public int pointCountMax;
        public double mutationAmountPointMin;
        public double mutationAmountPointMed;

        public int mutationChanceAlpha;
        public int mutationChanceRed;
        public int mutationChanceGreen;
        public int mutationChanceBlue;

        public int minValueAlpha;
        public int maxValueAlpha;
        public int minValueRed;
        public int maxValueRed;
        public int minValueGreen;
        public int maxValueGreen;
        public int minValueBlue;
        public int maxValueBlue;

        public const int SHAPE_POLYGON = 0;
        public const int SHAPE_CIRCLE = 1;

        public Settings() {
            useParallel = false;
            seed = (int)(DateTime.Now.Ticks % 1000000000);
            scale = 1;

            populationSize = 1;
            selectedAmount = 0.4;

            fittestSurvive = true;

            mutationChanceAddPolygon = 700;
            mutationChanceRemovePolygon = 1500;
            mutationChanceMovePolygon = 700;

            mutationChanceAddPoint = 1500;
            mutationChanceRemovePoint = 1500;
            mutationChancePointMin = 1500;
            mutationChancePointMed = 1500;
            mutationChancePointMax = 1500;

            mutationChanceAlpha = 1500;
            mutationChanceRed = 1500;
            mutationChanceGreen = 1500;
            mutationChanceBlue = 1500;

            minValueAlpha = 30;
            maxValueAlpha = 60;
            minValueRed = 0;
            maxValueRed = 255;
            minValueGreen = 0;
            maxValueGreen = 255;
            minValueBlue = 0;
            maxValueBlue = 255;

            polygonCountMin = 0;
            polygonCountMax = 144;

            pointCountMin = 3;
            pointCountMax = 10;

            polygonInitialScale = 0.01;
            mutationAmountPointMin = 0.01;
            mutationAmountPointMed = 0.1;
        }
    }
}
