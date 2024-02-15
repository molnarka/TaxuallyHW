namespace TaxuallyHW.Utils
{
    [Binding]
    public class ArgumentTransformations
    {
        [StepArgumentTransformation]
        public static int TransformToInt(string integerNumber)
        {
            return int.TryParse(integerNumber, out int result) ? result : 0;
        }
    }
}
