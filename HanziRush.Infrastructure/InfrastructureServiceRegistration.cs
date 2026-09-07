using HanziRush.Application.Interfaces;
using HanziRush.Infrastructure.Repositories;
using HanziRush.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HanziRush.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //Vocabulary
            services.AddScoped<IVocabularyRepository, VocabularyRepository>();
            services.AddScoped<ITextToSpeechService, EdgeTtsService>();

            //Book
            services.AddScoped<IBookRepository, BookRepository>();
            
            //Lesson            
            services.AddScoped<ILessonRepository, LessonRepository>();

            return services;
        }
    }
}
