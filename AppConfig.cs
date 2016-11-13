namespace TilesCutter
{
    public static class AppConfig
    {
        public static Encoder ImgEncoder = Encoder.PNG;
    }

    public enum Encoder
    {
        PNG,
        GIF,
        BMP,
        JPG
    }
}
