using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayXmlImportDto
    {
        [Required]
        [XmlElement("Title")]
        [MaxLength(GlobalConstants.PLAY_TITLE_MAX_LENGTH)]
        [MinLength(GlobalConstants.PLAY_TITLE_MIN_LENGTH)]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [XmlElement("Rating")]
        [Range(GlobalConstants.PLAY_RATING_MIN_VALUE, GlobalConstants.PLAY_RATING_MAX_VALUE)]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required]
        [XmlElement("Description")]
        [MaxLength(GlobalConstants.PLAY_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        [Required]
        [XmlElement("Screenwriter")]
        [MaxLength(GlobalConstants.PLAY_SCREENWRITER_MAX_LENGTH)]
        [MinLength(GlobalConstants.PLAY_SCREENWRITER_MIN_LENGTH)]
        public string Screenwriter { get; set; }
    }
}
