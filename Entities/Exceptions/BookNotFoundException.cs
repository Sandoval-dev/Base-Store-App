namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException //sealed sayesinde zırhlanan class. Herhangi bir şekilde kalıtılması mümkün değil.
    {
        public BookNotFoundException(int id) : base($"The book with id: {id} could not found.")
        {

        }
    }
}
