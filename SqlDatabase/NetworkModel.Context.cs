﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SqlDatabase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NetworkModelContainer : DbContext
    {
        public NetworkModelContainer()
            : base("name=NetworkModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<NodeType> NodeTypes { get; set; }
        public virtual DbSet<NodeStatus> NodeStatus { get; set; }
        public virtual DbSet<NodeColor> NodeColors { get; set; }
        public virtual DbSet<Edge> Edges { get; set; }
    }
}
