package com.example.lab_7_javafx_crud;

public class StudentModel {
    private int Id;
    private  String Name;
    private  String Surname;
    private  String Index;
    private  String Address;
    private  String Faculty;
    private  double Average ;
    private  int Year ;


    public StudentModel(int id, String name, String surname, String index, String address, String faculty, double average, int year) {
        Id = id;
        Name = name;
        Surname = surname;
        Index = index;
        Address = address;
        Faculty = faculty;
        Average = average;
        Year = year;
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getSurname() {
        return Surname;
    }

    public void setSurname(String surname) {
        Surname = surname;
    }

    public String getIndex() {
        return Index;
    }

    public void setIndex(String index) {
        Index = index;
    }

    public String getAddress() {
        return Address;
    }

    public void setAddress(String address) {
        Address = address;
    }

    public String getFaculty() {
        return Faculty;
    }

    public void setFaculty(String faculty) {
        Faculty = faculty;
    }

    public double getAverage() {
        return Average;
    }

    public void setAverage(double average) {
        Average = average;
    }

    public int getYear() {
        return Year;
    }

    public void setYear(int year) {
        Year = year;
    }
}
