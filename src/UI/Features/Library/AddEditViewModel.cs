namespace Headspring.Labs.UI.Features.Library
{
    using System;
    using Core.Domain;
    using Infrastructure;

    public class AddEditViewModel : IRequest<Book>
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
    }
}