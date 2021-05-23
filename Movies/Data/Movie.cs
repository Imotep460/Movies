using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data
{
    public class Thumbnail
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public double size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Formats
    {
        public Thumbnail thumbnail { get; set; }
    }

    public class Poster
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alternativeText { get; set; }
        public string caption { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Formats formats { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public double size { get; set; }
        public string url { get; set; }
        public object previewUrl { get; set; }
        public string provider { get; set; }
        public object provider_metadata { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Movie
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Poster> poster { get; set; }
    }
}
