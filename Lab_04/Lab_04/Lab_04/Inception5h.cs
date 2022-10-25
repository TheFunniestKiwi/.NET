using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;
using System.Drawing;

namespace ML
{
    public class ImageInputData
    {
        [ImageType(227, 227)]
        public Bitmap Image { get; set; }
    }

    public class ImageLabelPredictions
    {
        [ColumnName("softmax2")]
        public float[] PredictedLabels;
    }

    public class Inception5h
    {
        private PredictionEngine<ImageInputData, ImageLabelPredictions> pred;
        private string[] labels;

        public Inception5h()
        {
            var m = new MLContext();
            var model = m.Model.Load("inception5h.zip", out _);
            pred = m.Model.CreatePredictionEngine<ImageInputData, ImageLabelPredictions>(model);

            var labelsLocation = "labels.txt";
            labels = File.ReadAllLines(labelsLocation);
        }

        public (string, float) Label(Bitmap bitmapImage)
        {
            ImageInputData imageInputData = new ImageInputData { Image = bitmapImage };

            var result = pred.Predict(imageInputData);
            var probs = result.PredictedLabels.Take(1000).ToArray();

            var max = probs.Max();
            var index = probs.AsSpan().IndexOf(max);

            return (labels[index], max);
        }

        public (string, float) Label(Image image)
        {
            Bitmap bitmapImage = (Bitmap)image;

            return Label(bitmapImage);
        }

        public (string, float) Label(string path)
        {
            Image image = Image.FromFile(path);
            return Label(image);
        }
    }
}
