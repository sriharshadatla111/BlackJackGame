﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class Entities6 : DbContext
{
    public Entities6()
        : base("name=Entities6")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Account_Details> Account_Details { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<CardInfo> CardInfoes { get; set; }
    public virtual DbSet<Card> Cards { get; set; }
    public virtual DbSet<Score> Scores { get; set; }
    public virtual DbSet<User_Bank_Details> User_Bank_Details { get; set; }
    public virtual DbSet<User_Funds> User_Funds { get; set; }
    public virtual DbSet<User_Profile_Details> User_Profile_Details { get; set; }
    public virtual DbSet<User> Users { get; set; }
}