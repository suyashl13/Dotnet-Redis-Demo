namespace ServiceContracts.DTO;

public class TodoResponse
{
    public Guid TodoId { get; set; }

    public String Title { get; set; } = null!;
    public String Description { get; set; } = null!;
    public bool IsDone { get; set; }
}