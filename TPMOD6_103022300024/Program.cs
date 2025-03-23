﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    // Constructor dengan Prekondisi
    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title), "Judul video tidak boleh null atau kosong");
        Debug.Assert(title.Length <= 100, "Judul video tidak boleh lebih dari 100 karakter");


        Random random = new Random();
        this.id = random.Next(10000, 99999); // Generate random 5-digit id
        this.title = title;
        this.playCount = 0; // Initialize playCount to 0
    }

    // Method untuk menambah play count dengan validasi
    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0 && count <= 10000000, "Jumlah play count harus antara 1 dan 10.000.000");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow saat menambah play count!");
        }
    }

    // Method untuk mencetak detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine("==========================");
        Console.WriteLine($"ID: {this.id}");
        Console.WriteLine($"Title: {this.title}");
        Console.WriteLine($"Play Count: {this.playCount}");
        Console.WriteLine("==========================");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Menguji prekondisi (judul valid dan panjang tidak lebih dari 100 karakter)
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – jack kelvin G.R");
            video.PrintVideoDetails();

            // Menguji batas maksimal play count (valid input)
            video.IncreasePlayCount(10000000);
            video.PrintVideoDetails();

            // Menguji exception overflow dengan loop
            for (int i = 0; i < 50; i++)
            {
                video.IncreasePlayCount(10000000); // Loop untuk memaksa overflow
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Terjadi kesalahan: " + ex.Message);
        }
    }
}

