using System.IO;

namespace ProfileV2Test.Infrastructure
{
    public static class PathsToFiles
    {
        public static string PathToImageIsLessThan3Mb = Path.GetFullPath(@"..\ProfileV2Test\FileForTest2.2\LessThan3MB.jpg");

        public static string PathToImageIsBiggerThan3Mb = Path.GetFullPath(@"..\ProfileV2Test\FileForTest2.2\BiggerThan3MB.jpg");
    }
}