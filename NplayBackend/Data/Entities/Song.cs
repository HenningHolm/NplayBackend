﻿namespace NplayBackend.Data.Entities;
public class Song
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public int Published { get; set; }
}