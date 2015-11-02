using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using IZ.MovemberApp.Models;

namespace IZ.MovemberApp.Migrations
{
    [DbContext(typeof(IzMovemberContext))]
    [Migration("20151030212118_UserContext")]
    partial class UserContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IZ.MovemberApp.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IZ.MovemberApp.Models.Rating", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("PostId");

                    b.HasKey("RateId");
                });

            modelBuilder.Entity("IZ.MovemberApp.Models.User", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("userId");
                });

            modelBuilder.Entity("IZ.MovemberApp.Models.Rating", b =>
                {
                    b.HasOne("IZ.MovemberApp.Models.Post")
                        .WithMany()
                        .ForeignKey("PostId");
                });
        }
    }
}
