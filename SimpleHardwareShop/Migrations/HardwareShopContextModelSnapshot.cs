// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleHardwareShop.Data;

#nullable disable

namespace SimpleHardwareShop.Migrations
{
    [DbContext(typeof(HardwareShopContext))]
    partial class HardwareShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("SimpleHardwareShop.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CustomerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmployeeUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PostalCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RFC")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAdress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("EmployeeUserId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("ApplicationUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.BankCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.CotizacionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("YaSeEnvioAlCliente")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("CotizacionDetails");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeliveryAdressId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FiscalAdressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("DeliveryAdressId");

                    b.HasIndex("FiscalAdressId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DefaultStock")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Inventory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("RetailShop")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Stock")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.CustomerUser", b =>
                {
                    b.HasBaseType("SimpleHardwareShop.Models.ApplicationUser");

                    b.Property<int?>("DefaultBankCardId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DefaultDeliveryAdressId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DefaultFiscalAdressId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("CustomerUser");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.EmployeeUser", b =>
                {
                    b.HasBaseType("SimpleHardwareShop.Models.ApplicationUser");

                    b.Property<int?>("EmployeeAdressId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RetailShop")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("EmployeeUser");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.Adress", b =>
                {
                    b.HasOne("SimpleHardwareShop.Models.CustomerUser", null)
                        .WithMany("Adresses")
                        .HasForeignKey("CustomerUserId");

                    b.HasOne("SimpleHardwareShop.Models.EmployeeUser", null)
                        .WithMany("Adresses")
                        .HasForeignKey("EmployeeUserId");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.BankCard", b =>
                {
                    b.HasOne("SimpleHardwareShop.Models.CustomerUser", null)
                        .WithMany("BankCards")
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.CotizacionDetail", b =>
                {
                    b.HasOne("SimpleHardwareShop.Models.CustomerUser", "CustomerUser")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleHardwareShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.OrderDetail", b =>
                {
                    b.HasOne("SimpleHardwareShop.Models.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleHardwareShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.OrderHeader", b =>
                {
                    b.HasOne("SimpleHardwareShop.Models.CustomerUser", "CustomerUser")
                        .WithMany("OrderHeaders")
                        .HasForeignKey("CustomerUserId");

                    b.HasOne("SimpleHardwareShop.Models.Adress", "DeliveryAdress")
                        .WithMany()
                        .HasForeignKey("DeliveryAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleHardwareShop.Models.Adress", "FiscalAdress")
                        .WithMany()
                        .HasForeignKey("FiscalAdressId");

                    b.Navigation("CustomerUser");

                    b.Navigation("DeliveryAdress");

                    b.Navigation("FiscalAdress");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.ShoppingCart", b =>
                {
                    b.HasOne("SimpleHardwareShop.Models.CustomerUser", "CustomerUser")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleHardwareShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.CustomerUser", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("BankCards");

                    b.Navigation("OrderHeaders");
                });

            modelBuilder.Entity("SimpleHardwareShop.Models.EmployeeUser", b =>
                {
                    b.Navigation("Adresses");
                });
#pragma warning restore 612, 618
        }
    }
}
