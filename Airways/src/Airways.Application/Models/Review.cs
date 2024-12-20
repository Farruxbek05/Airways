﻿namespace Airways.Application.Models;

public class Review
{
    public int ID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid User_id { get; set; }
    public Guid Reys_id { get; set; }
}
