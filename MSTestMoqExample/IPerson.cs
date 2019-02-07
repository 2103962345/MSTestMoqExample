namespace MSTestMoqExample
{
    public interface IPerson
    {
        int BirthYear { get; set; }

        Person.Gender GetGender();
    }
}