using System;

namespace Problem4_OnlineRadioDatabase
{
    public class Song
    {
        // Encapsulation: internal state is hidden from outside access
        private string artist;
        private string songName;
        private long minutes;
        private long seconds;
        private TimeSpan songLength;

        // Constructor enforces valid object creation (domain rules applied here)
        public Song(string artist, string songName, long minutes, long seconds)
        {
            this.Artist = artist;      // validation inside property
            this.SongName = songName;  // validation inside property
            this.Minutes = minutes;    // validation inside property
            this.Seconds = seconds;    // validation inside property

            // Composition of behavior: derived value computed once during construction
            this.songLength = CalculateSongLength(this.Minutes, this.Seconds);
        }

        // Read-only property: exposes computed song duration
        public TimeSpan SongLength
        {
            get
            {
                return this.songLength;
            }
        }

        // Encapsulated logic: converts minutes + seconds into TimeSpan
        private TimeSpan CalculateSongLength(long minutes, long seconds)
        {
            long totalSeconds = minutes * 60 + seconds;

            // TimeSpan abstracts time duration handling
            return TimeSpan.FromSeconds(totalSeconds);
        }

        // Validation: ensures seconds are within valid time range
        public long Seconds
        {
            get { return this.seconds; }
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }

                this.seconds = value;
            }
        }

        // Validation: ensures minutes are within allowed constraints
        public long Minutes
        {
            get { return this.minutes; }
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }

                this.minutes = value;
            }
        }

        // Validation: ensures song name length is valid (domain rule)
        public string SongName
        {
            get { return this.songName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }

                this.songName = value;
            }
        }

        // Validation: ensures artist name meets business rules
        public string Artist
        {
            get { return this.artist; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                this.artist = value;
            }
        }
    }
}