using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NukeLogin.Infrastructure.MapSettings.Base;
using NukeLogin.Src.Domain.Models;

namespace NukeLogin.Infrastructure.MapSettings.DomainMap.AccessControl
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("users");

            #region Person
            builder.OwnsOne(x => x.Person, person =>
            {
                person.OwnsOne(x => x.Name, name =>
                {
                    name.Property(x => x.FirstName).HasColumnName("first_name");
                    name.Property(x => x.LastName).HasColumnName("last_name");
                });

                person.Property(x => x.BirthDate).HasColumnName("birth_date");

                person.OwnsOne(x => x.Cpf, cpf =>
                {
                    cpf.Property(x => x.Numbers).HasColumnName("cpf_numbers");
                    cpf.Property(x => x.Validators).HasColumnName("cpf_validators");
                });
            });
            #endregion

            #region Address
            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(x => x.ZipCode).HasColumnName("address_zip_code");
                address.Property(x => x.Region).HasColumnName("address_region");
                address.Property(x => x.State).HasColumnName("address_state");
                address.Property(x => x.City).HasColumnName("address_city");
                address.Property(x => x.Neighborhood).HasColumnName("address_neighborhood");
                address.Property(x => x.Street).HasColumnName("address_street");
                address.Property(x => x.Number).HasColumnName("address_number");
                address.Property(x => x.Complement).HasColumnName("address_complement");
            });
            #endregion

            #region Email
            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Address).HasColumnName("email_address");
                email.Property(x => x.Domain).HasColumnName("email_domain");
            });
            #endregion

            #region Phone
            builder.OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(x => x.CountryCode).HasColumnName("phone_country_code");
                phone.Property(x => x.Number).HasColumnName("phone_number");
            });
            #endregion

            #region Password
            builder.OwnsOne(x => x.Password, password =>
            {
                password.Property(x => x.Hash).HasColumnName("password_hash");
            });
            #endregion

            builder.Property(x => x.Status).HasColumnName("account_status");
        }
    }
}
