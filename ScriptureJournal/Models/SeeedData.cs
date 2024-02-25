using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;

namespace ScriptureJournal.Models;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ScriptureJournalContext>>()))
        {
            if (context == null || context.Scripture == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any scriptures.
            if (context.Scripture.Any())
            {
                return;   // DB has been seeded
            }

            context.Scripture.AddRange(
                new Scripture
                {
                    DateAdded = DateTime.Parse("2024-2-24"),
                    Book = "1 Nephi",
                    Verse = "10:11",
                    Notes = "Good stuff"
                },
                new Scripture
                {
                    DateAdded = DateTime.Parse("2024-2-24"),
                    Book = "2 Nephi",
                    Verse = "1:1",
                    Notes = "I really enjoyed this scripture"
                }
            );
            context.SaveChanges();
        }
    }
}