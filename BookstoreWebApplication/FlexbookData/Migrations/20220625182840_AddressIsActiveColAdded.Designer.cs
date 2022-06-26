﻿// <auto-generated />
using System;
using FlexbookData.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlexbookData.Migrations
{
    [DbContext(typeof(FlexbookContext))]
    [Migration("20220625182840_AddressIsActiveColAdded")]
    partial class AddressIsActiveColAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FlexbookData.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("postcode");

                    b.HasKey("Id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("FlexbookData.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("content");

                    b.Property<DateTime>("DateWritten")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datetime_written");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("image_path");

                    b.Property<int>("Likes")
                        .HasColumnType("integer")
                        .HasColumnName("likes");

                    b.Property<int>("conversation_id")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("conversation_id");

                    b.HasIndex("user_id");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("FlexbookData.Models.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("host_id")
                        .HasColumnType("integer");

                    b.Property<int>("initial_comment_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("host_id");

                    b.HasIndex("initial_comment_id");

                    b.ToTable("conversations");
                });

            modelBuilder.Entity("FlexbookData.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Discount")
                        .HasColumnType("real")
                        .HasColumnName("discount");

                    b.Property<DateTime>("Ordered_Time")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ordered_time");

                    b.Property<string>("Payment_Method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("payment_method");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("status");

                    b.Property<int>("Total_Price")
                        .HasColumnType("integer")
                        .HasColumnName("total_price");

                    b.Property<int>("customer_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("customer_id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("FlexbookData.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("order_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("order_id");

                    b.HasIndex("product_id");

                    b.ToTable("order_items");
                });

            modelBuilder.Entity("FlexbookData.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Final_Price")
                        .HasColumnType("integer")
                        .HasColumnName("final_price");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("image_path");

                    b.Property<int>("Starting_Price")
                        .HasColumnType("integer")
                        .HasColumnName("starting_price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("FlexbookData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("email");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("fullname");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("image_path");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("phone_num");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.Property<int>("address_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("address_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FlexbookData.Models.Author", b =>
                {
                    b.HasBaseType("FlexbookData.Models.User");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(510)
                        .HasColumnType("character varying(510)")
                        .HasColumnName("description");

                    b.ToTable("authors", (string)null);
                });

            modelBuilder.Entity("FlexbookData.Models.Book", b =>
                {
                    b.HasBaseType("FlexbookData.Models.Product");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("genre");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("isbn");

                    b.Property<DateOnly>("Language")
                        .HasMaxLength(50)
                        .HasColumnType("date")
                        .HasColumnName("language");

                    b.Property<int>("Pages")
                        .HasColumnType("integer")
                        .HasColumnName("pages");

                    b.Property<DateOnly>("Publication_Date")
                        .HasColumnType("date")
                        .HasColumnName("publication_date");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("publisher");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("summary");

                    b.Property<int>("author_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.HasIndex("author_id");

                    b.HasIndex("product_id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("FlexbookData.Models.Customer", b =>
                {
                    b.HasBaseType("FlexbookData.Models.User");

                    b.Property<string>("FaxNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fax_num");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("FlexbookData.Models.Comment", b =>
                {
                    b.HasOne("FlexbookData.Models.Conversation", "Conversation")
                        .WithMany()
                        .HasForeignKey("conversation_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexbookData.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexbookData.Models.Conversation", b =>
                {
                    b.HasOne("FlexbookData.Models.User", "Host")
                        .WithMany()
                        .HasForeignKey("host_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexbookData.Models.Comment", "InitialComment")
                        .WithMany()
                        .HasForeignKey("initial_comment_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");

                    b.Navigation("InitialComment");
                });

            modelBuilder.Entity("FlexbookData.Models.Order", b =>
                {
                    b.HasOne("FlexbookData.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FlexbookData.Models.OrderItem", b =>
                {
                    b.HasOne("FlexbookData.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexbookData.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FlexbookData.Models.User", b =>
                {
                    b.HasOne("FlexbookData.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("address_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FlexbookData.Models.Author", b =>
                {
                    b.HasOne("FlexbookData.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FlexbookData.Models.Author", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlexbookData.Models.Book", b =>
                {
                    b.HasOne("FlexbookData.Models.Product", null)
                        .WithOne()
                        .HasForeignKey("FlexbookData.Models.Book", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexbookData.Models.Author", "author")
                        .WithMany()
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexbookData.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("product");
                });

            modelBuilder.Entity("FlexbookData.Models.Customer", b =>
                {
                    b.HasOne("FlexbookData.Models.User", null)
                        .WithOne()
                        .HasForeignKey("FlexbookData.Models.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
