using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite
{
    public static class DataInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Id = 1,
                        Title = "Covid19",
                        Text = "Коронавирусная инфекция COVID-19 – это инфекционное заболевание, вызванное новым коронавирусом, " +
                        "который ранее у людей не обнаруживался." +
                        "Воздействие данного вируса приводит к развитию респираторного гриппоподобного заболевания с такими симптомами как кашель, " +
                        "лихорадка и, в более тяжелых случаях, пневмония.Для защиты от инфекции следует часто мыть руки и не прикасаться руками к лицу."
                    }
                );
                context.SaveChanges();
            }
    }
        }
}
