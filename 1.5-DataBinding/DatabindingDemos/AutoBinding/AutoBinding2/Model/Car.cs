namespace AutoBinding2.Model
{
    public class Car
    {
        public string Model { get; set; }

        public string Image { get; set; }

        // Demo: Uncomment this code to show the effect of ToString() if no DataTemplate is applied
        //public override string ToString()
        //{
        //    return $"{this.Model} {this.Image}";
        //}
    }
}