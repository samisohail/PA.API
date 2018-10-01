using API.DataObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.DataAccess.DataContext
{
    public interface IPA24Context : IDbContext
    {
        DbSet<AlertTypes> AlertTypes { get; set; }
        DbSet<ConfigurationTypes> ConfigurationTypes { get; set; }
        DbSet<DocumentCategories> DocumentCategories { get; set; }
        DbSet<DocumentsDetails> DocumentsDetails { get; set; }
        DbSet<DocumentsStore> DocumentsStore { get; set; }
        DbSet<Organisations> Organisations { get; set; }
        DbSet<OrgConfigurations> OrgConfigurations { get; set; }
        DbSet<ParentTasks> ParentTasks { get; set; }
        DbSet<Projects> Projects { get; set; }
        DbSet<ProjectTasks> ProjectTasks { get; set; }
        DbSet<ProjectTeamMembers> ProjectTeamMembers { get; set; }
        DbSet<ProjectTypes> ProjectTypes { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<TasksChat> TasksChat { get; set; }
        DbSet<UserRoles> UserRoles { get; set; }
        DbSet<Users> Users { get; set; }
    }
}
