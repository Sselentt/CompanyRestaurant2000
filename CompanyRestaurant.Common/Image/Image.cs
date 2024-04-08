namespace CompanyRestaurant.Common.Image
{
    public static class Image
    {
        private static readonly HashSet<string> AllowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".png", ".jpg", ".jpeg", ".gif"
        };

        public static string GenerateFileName(string originalFileName)
        {
            if (string.IsNullOrWhiteSpace(originalFileName))
            {
                throw new ArgumentException("Original file name must not be null or whitespace.", nameof(originalFileName));
            }

            var extension = Path.GetExtension(originalFileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"The file extension '{extension}' is not allowed.");
            }

            return $"{Guid.NewGuid()}{extension}";
        }
    }
}
