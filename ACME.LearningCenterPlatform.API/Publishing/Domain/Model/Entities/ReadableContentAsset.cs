using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents an asset that contains readable content, such as articles or documents.
/// </summary>
public class ReadableContentAsset : Asset
{
    /// <summary>
    /// The readable content of the asset.
    /// </summary>
    public string ReadableContent { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadableContentAsset"/> class.
    /// </summary>
    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = string.Empty;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadableContentAsset"/> class with specified content.
    /// </summary>
    /// <param name="content">The readable content of the asset.</param>
    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }

    /// <summary>
    /// Indicates whether the asset is readable.
    /// </summary>
    public override bool Readable => true;

    /// <summary>
    /// Indicates whether the asset is viewable.
    /// </summary>
    public override bool Viewable => false;
}