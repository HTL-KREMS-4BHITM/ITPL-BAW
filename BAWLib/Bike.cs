
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BAWLib;

public class Bike
{
    public Bike()
    {
        
    }
    public Bike(int id, int ps, int weight, int seatHeight, string model, string manufacturer, double currentLeasingRate, double kilomerter)
    {
        this.Id = id;
        this.Ps = ps;
        this.Weight = weight;
        this.Seatheight = seatHeight;
        this.Kilomerter = kilomerter;
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.CurrentLeasingRate = currentLeasingRate;
        this.Kilomerter = kilomerter;
    }
    public Bike(int id, int ps, int weight, int seatHeight, string model, string manufacturer, double currentLeasingRate, double kilomerter, string ImgOne, string ImgTwo, string imgThree)
    {
        this.Id = id;
        this.Ps = ps;
        this.Weight = weight;
        this.Seatheight = seatHeight;
        this.Kilomerter = kilomerter;
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.CurrentLeasingRate = currentLeasingRate;
        this.Kilomerter = kilomerter;
        this.ImgOne = ImgOne;
        this.ImgTwo = ImgTwo;
        this.ImgThree = ImgThree;
    }
    
    
    public int Id {get; set;}
    public int Ps { get; set; }
    public int Weight { get; set; }
    public int Seatheight { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public double CurrentLeasingRate { get; set; }
    public double Kilomerter { get; set; }

    public string ImgOne { get; set; }
    public string ImgTwo { get; set; }
    public string ImgThree { get; set; }
}