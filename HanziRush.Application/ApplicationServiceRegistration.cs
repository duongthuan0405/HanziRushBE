using HanziRush.Application.Features.Audio.GeneratePronunciation;
using HanziRush.Application.Features.Books.CreateBook;
using HanziRush.Application.Features.Books.DeleteBook;
using HanziRush.Application.Features.Books.GetBooks;
using HanziRush.Application.Features.Books.UpdateBook;
using HanziRush.Application.Features.Lessons.CreateLesson;
using HanziRush.Application.Features.Lessons.DeleteLesson;
using HanziRush.Application.Features.Lessons.GetLessons;
using HanziRush.Application.Features.Lessons.UpdateLesson;
using HanziRush.Application.Features.Vocabularies.GetRandomVocabulary;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HanziRush.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Vocabulary
            services.AddScoped<GetRandomVocabularyUseCase>();

            //Pronunciation
            services.AddScoped<GeneratePronunciationUseCase>();

            //Book
            services.AddScoped<GetBooksUseCase>();            
            services.AddScoped<CreateBookUseCase>();
            services.AddScoped<UpdateBookUseCase>();
            services.AddScoped<DeleteBookUseCase>();

            //Lesson
            services.AddScoped<GetLessonsUseCase>();
            services.AddScoped<CreateLessonUseCase>();
            services.AddScoped<UpdateLessonUseCase>();
            services.AddScoped<DeleteLessonUseCase>();

            return services;
        }
    }
}
