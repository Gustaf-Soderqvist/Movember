using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using IZ.MovemberApp.Models;

namespace IZ.MovemberApp.Migrations
{
    [ContextType(typeof(IzMovemberContext))]
    partial class IZMovemberContext
    {
        public override string Id
        {
            get { return "20151024165417_IZMovemberContext"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("IZ.MovemberApp.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<string>("FirstName");
                    
                    b.Property<string>("LastName");
                    
                    b.Key("AuthorId");
                });
            
            builder.Entity("IZ.MovemberApp.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<int>("AuthorId");
                    
                    b.Property<string>("Description");
                    
                    b.Property<string>("Image");
                    
                    b.Property<string>("Name");
                    
                    b.Key("Id");
                });
            
            builder.Entity("IZ.MovemberApp.Models.Post", b =>
                {
                    b.Reference("IZ.MovemberApp.Models.Author")
                        .InverseCollection()
                        .ForeignKey("AuthorId");
                });
        }
    }
}
