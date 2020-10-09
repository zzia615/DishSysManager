namespace DishSysManager
{
    public class MenuInfo:System.EventArgs
    {
        public int id { get; set; }
        public string title { get; set; }
        public string img_url { get; set; }
        public double price { get; set; }
        public bool isTjc { get; set; }
        public bool isRxc { get; set; }
    }
}
