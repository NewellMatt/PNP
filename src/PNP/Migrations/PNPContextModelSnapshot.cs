using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using PNP.Models;

namespace PNP.Migrations
{
    [DbContext(typeof(PNPContext))]
    partial class PNPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PNP.Models.Story", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("StoryId");

                    b.HasAnnotation("Relational:TableName", "Stories");
                });
        }
    }
}
