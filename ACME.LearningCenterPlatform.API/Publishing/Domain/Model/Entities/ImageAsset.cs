using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents an image asset in the publishing bounded context.
/// </summary>
public class ImageAsset : Asset
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageAsset"/> class.
    /// </summary>
    public ImageAsset() : base(EAssetType.Image)
    {
    }

    /// <summary>
    /// Gets the URI of the image.
    /// </summary>
    public Uri? ImageUri { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageAsset"/> class with the specified image URL.
    /// </summary>
    /// <param name="imageUrl">The URL of the image.</param>
    public ImageAsset(string imageUrl) : base(EAssetType.Image)
    {
        ImageUri = new Uri(imageUrl);
    }

    public override bool Readable => false;

    public override bool Viewable => true;

    /// <summary>
    /// Gets the content of the image asset.
    /// </summary>
    /// <returns>>The URI of the image as a string.</returns>
    public override string GetContent()
    {
        return ImageUri is not null
            ? ImageUri.AbsoluteUri
            : string.Empty;
    }
}