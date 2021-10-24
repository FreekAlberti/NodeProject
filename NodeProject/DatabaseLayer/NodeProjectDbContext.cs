using Microsoft.EntityFrameworkCore;
using NodeProject.DatabaseLayer.Models;
using System;

namespace NodeProject.DatabaseLayer
{
    public class NodeProjectDbContext : DbContext
    {
        public NodeProjectDbContext(DbContextOptions<NodeProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobSector> JobSectors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddress { get; set; }
        public DbSet<UserEducation> UsersEducations { get; set; }
        public DbSet<UserWorkExperience> UsersWorkExperience { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(left => left.Vacancies)
                .WithMany(right => right.Users)
                .UsingEntity<UserVacancy>(
                    right => right.HasOne(e => e.Vacancy).WithMany(),
                    left => left.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserID),
                    join => join.ToTable("UserVacancy")
                );
            modelBuilder.Entity<User>()
                .HasMany(left => left.Companies)
                .WithMany(right => right.Users)
                .UsingEntity<UserCompany>(
                    right => right.HasOne(e => e.Company).WithMany(),
                    left => left.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserID),
                    join => join.ToTable("UserCompany")
                );
            DatabaseSeed(modelBuilder);
        }

        private void DatabaseSeed(ModelBuilder modelBuilder)
        {
            DateTime dateBirth = Convert.ToDateTime("11/12/1996");
            DateTime dateStartWork = Convert.ToDateTime("08/10/2016");
            DateTime dateStartStudy = Convert.ToDateTime("04/05/2006");
            DateTime datePublicatioVacancy = Convert.ToDateTime("11/03/2020");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    UserName = "Federico",
                    UserSurname = "Alberti",
                    UserImage = @"https://docs.microsoft.com/it-it/virtualization/windowscontainers/manage-containers/media/microsoft_logo.svg",
                    UserEmail = "federicoalberti96@gmail.com",
                    UserCell = "333-1111-222",
                    UserDateOfBirth = dateBirth
                });
            modelBuilder.Entity<JobSector>().HasData(
                new JobSector
                {
                    JobSectorID = 1,
                    JobSectorName = "Tecnology",
                    JobSectorDescription = "The technology sector is the category of stocks relating to the research, development, or distribution of technologically based goods and services."
                },
                new JobSector
                {
                    JobSectorID = 2,
                    JobSectorName = "Tourism",
                    JobSectorDescription = "Tourism is the activities of people traveling to and staying in places outside their usual environment for leisure, business or other purposes for not more than one consecutive year."
                });
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyID = 1,
                    CompanyName = "Microsoft",
                    CompanyImage = @"https://docs.microsoft.com/it-it/virtualization/windowscontainers/manage-containers/media/microsoft_logo.svg",
                    CompanyDescription = "Microsoft Corporation is an American multinational technology corporation which produces computer software, consumer electronics, personal computers, and related services.",
                    HeadquarterLocation = "One Microsoft Way Redmond, Washington, U.S.",
                    JobSectorID = 1
                },
                new Company
                {
                    CompanyID = 2,
                    CompanyName = "Apple",
                    CompanyImage = @"https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?201609051049",
                    CompanyDescription = "Apple Inc. is an American multinational technology company that specializes in consumer electronics, computer software, and online services.",
                    HeadquarterLocation = "Cupertino, California, United States",
                    JobSectorID = 1
                });
            modelBuilder.Entity<UserAddress>().HasData(
                new UserAddress
                {
                    UserAddressID = 1,
                    UserAddressStreet = "Route 66",
                    UserAddressCity = "Berlin",
                    UserAddressRegion = "Latium",
                    UserAddressCountry = "Spain",
                    UserAddressPosteCode = 123443,
                    UserID = 1
                });
            modelBuilder.Entity<UserWorkExperience>().HasData(
                new UserWorkExperience
                {
                    UserID = 1,
                    UserWorkExperienceID = 1,
                    UserWorkExperienceStartDate = dateStartWork,
                    UserWorkExperienceRole = "Web Developer",
                    UserWorkExperienceTask = "Develop, Debbug and Publish",
                    UserWorkExperienceOtherInfo = "Smart Working",
                    UserWorkExperienceCompanyName = "Apple"
                });
            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy
                {
                    VacancyID = 1,
                    VacancyTitle = "Web Developer",
                    VacancyDescription = "Full Stack Web Developer with .Net5 and Angular experience",
                    CompanyID = 1,
                    VacancyIsVisible = true,
                    VacancyBenefits = "Free coffee",
                    VacancyPublish = datePublicatioVacancy,
                    VacancySalary = 4234.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 2,
                    VacancyTitle = "Junior Web Developer",
                    VacancyDescription = "Full Stack Web Developer with .Net5 and Angular experience",
                    VacancyIsVisible = true,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 1,
                    VacancyPublish = datePublicatioVacancy.AddDays(1),
                    VacancySalary = 234.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 3,
                    VacancyTitle = "Middle Web Developer",
                    VacancyDescription = "Full Stack Web Developer with .Net5 and Angular experience",
                    VacancyIsVisible = false,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 2,
                    VacancyPublish = datePublicatioVacancy.AddDays(4),
                    VacancySalary = 2344.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 4,
                    VacancyTitle = "Developer",
                    VacancyDescription = "Full Stack Web Developer with .Net5 and Angular experience",
                    VacancyIsVisible = true,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 1,
                    VacancyPublish = datePublicatioVacancy.AddDays(-1),
                    VacancySalary = 23434.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 5,
                    VacancyTitle = "Junior Developer",
                    VacancyDescription = "Full Stack Web Developer with .Net5 and Angular experience",
                    VacancyIsVisible = true,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 1,
                    VacancyPublish = datePublicatioVacancy,
                    VacancySalary = 2334.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 6,
                    VacancyTitle = "Junior Web Developer",
                    VacancyDescription = "Full Stack Web Developer with .Net5 and Angular experience",
                    VacancyIsVisible = true,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 2,
                    VacancyPublish = datePublicatioVacancy.AddDays(1),
                    VacancySalary = 2346.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 7,
                    VacancyTitle = "Software Developer",
                    VacancyDescription = "Software Developer with .Net5 and Angular experience",
                    VacancyIsVisible = false,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 2,
                    VacancyPublish = datePublicatioVacancy,
                    VacancySalary = 22346.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 8,
                    VacancyTitle = "Software Developer",
                    VacancyDescription = "Software Developer with experience",
                    VacancyIsVisible = false,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 1,
                    VacancyPublish = datePublicatioVacancy.AddDays(1),
                    VacancySalary = 22346.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 9,
                    VacancyTitle = "Software Developer",
                    VacancyDescription = "Software Developer with experience",
                    VacancyIsVisible = false,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 2,
                    VacancyPublish = datePublicatioVacancy.AddDays(3),
                    VacancySalary = 22346.12,
                    AmministratorID = 1
                }
                , new Vacancy
                {
                    VacancyID = 10,
                    VacancyTitle = "Software Developer",
                    VacancyDescription = "Software Developer with experience",
                    VacancyIsVisible = true,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 1,
                    VacancyPublish = datePublicatioVacancy.AddDays(2),
                    VacancySalary = 22346.12,
                    AmministratorID = 1
                },
                new Vacancy
                {
                    VacancyID = 11,
                    VacancyTitle = "Software Developer",
                    VacancyDescription = "Software Developer with experience",
                    VacancyIsVisible = false,
                    VacancyBenefits = "Free coffee",
                    CompanyID = 2,
                    VacancyPublish = datePublicatioVacancy.AddDays(5),
                    VacancySalary = 22346.12,
                    AmministratorID = 1
                }
                );
            modelBuilder.Entity<UserEducation>().HasData(
                new UserEducation
                {
                    UserID = 1,
                    UserEducationID = 1,
                    UserEducationFieldOfStudy = "Engineering",
                    UserEducationFinalMark = "104/110",
                    UserEducationSchool = "MIT",
                    UserEducationOtherInfo = "It was funny",
                    UserEducationStartDate = dateStartStudy
                });
            modelBuilder.Entity<Amministrator>().HasData(
                new Amministrator
                {
                    AmministratorID = 1,
                    AmministratorName = "MasterAdmin1",
                });
            modelBuilder.Entity<UserVacancy>().HasData(
                new UserVacancy
                {
                    UserID = 1,
                    VacancyID = 1
                },
                new UserVacancy
                {
                    UserID = 1,
                    VacancyID = 5
                },
                new UserVacancy
                {
                    UserID = 1,
                    VacancyID = 6
                }
                );
            modelBuilder.Entity<UserCompany>().HasData(
                new UserCompany
                {
                    UserID = 1,
                    CompanyID = 1
                });
            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    RequestID = 1,
                    RequestTitle = "Request Vacancy new Engineer",
                    RequestContent = "We are looking for new Engineer with Oracle Database experience",
                    CompanyID = 2,
                },
                new Request
                {
                    RequestID = 2,
                    RequestTitle = "Request Vacancy new Developer",
                    RequestContent = "We are looking for new Developer with Oracle Database experience",
                    CompanyID = 2,
                },
                new Request
                {
                    RequestID = 3,
                    RequestTitle = "Request Vacancy Engineer",
                    RequestContent = "We are looking for Engineer with Oracle Database experience",
                    CompanyID = 1,
                },
                new Request
                {
                    RequestID = 4,
                    RequestTitle = "Request Vacancy new Engineer",
                    RequestContent = "We are looking for new Engineer with Oracle Database experience",
                    CompanyID = 1,
                },
                new Request
                {
                    RequestID = 5,
                    RequestTitle = "Request Vacancy new Engineer",
                    RequestContent = "We are looking for new Engineer with Oracle Database experience",
                    CompanyID = 2,
                });
        }
    }
}
