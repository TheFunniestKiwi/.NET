package com.example.lab_7_javafx_crud;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;

import javafx.event.ActionEvent;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;

import java.net.URL;
import java.sql.*;
import java.util.ResourceBundle;

public class HelloController implements Initializable {
    //Connection con;
    //PreparedStatement pst;
    int MyIndex;
    int id;



    @FXML
    private Button btnAdd;
    @FXML
    private Button btnDelete;
    @FXML
    private Button btnUpdate;
    @FXML
    private TableColumn<StudentModel, String> columnName;
    @FXML
    private TableColumn<StudentModel, String> columnAddress;
    @FXML
    private TableColumn<StudentModel, Double> columnAverage;
    @FXML
    private TableColumn<StudentModel, String> columnFaculty;
    @FXML
    private TableColumn<StudentModel, Integer> columnID;
    @FXML
    private TableColumn<StudentModel, String> columnIndex;
    @FXML
    private TableColumn<StudentModel, String > columnSurname;
    @FXML
    private TableColumn<StudentModel, Integer> columnYear;
    @FXML
    private TableView<StudentModel> tableDb;
    @FXML
    private TextField textAddress;
    @FXML
    private TextField textAverage;
    @FXML
    private TextField textFaculty;
    @FXML
    private TextField textIndex;
    @FXML
    private TextField textName;
    @FXML
    private TextField textSurname;
    @FXML
    private TextField textYear;

    private StudentModel student;




    public Connection getConnection(){
        Connection conn;
        try {
            conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/java", "root", "");
            return conn;
        }catch (Exception ex){
            System.out.println("Bazy ni mo" + ex.getMessage());
            return null;
        }
    }

    public ObservableList<StudentModel> getStudents(){
        ObservableList<StudentModel> studentsList = FXCollections.observableArrayList();
        Connection conn = getConnection();
        String query  = "SELECT * FROM students";
        Statement st;
        ResultSet rs;

        try {
            st = conn.createStatement();
            rs = st.executeQuery(query);
            StudentModel student;
            while(rs.next()){
                student = new StudentModel(rs.getInt("Id"),
                        rs.getString("Name"),
                        rs.getString("Surname"),
                        rs.getString("IndexNumber"),
                        rs.getString("Address"),
                        rs.getString("Faculty"),
                        rs.getDouble("Average"),
                        rs.getInt("Year"));
                studentsList.add(student);
            }
        }catch (Exception ex){
            ex.printStackTrace();
        }
        return studentsList;
    }

    public void showStudents(){
        ObservableList<StudentModel> studentsList = getStudents();

        columnID.setCellValueFactory(new PropertyValueFactory<StudentModel, Integer>("Id"));
        columnName.setCellValueFactory(new PropertyValueFactory<StudentModel, String>("Name"));
        columnSurname.setCellValueFactory(new PropertyValueFactory<StudentModel, String>("Surname"));
        columnIndex.setCellValueFactory(new PropertyValueFactory<StudentModel, String>("Index"));
        columnAddress.setCellValueFactory(new PropertyValueFactory<StudentModel, String>("Address"));
        columnFaculty.setCellValueFactory(new PropertyValueFactory<StudentModel, String>("Faculty"));
        columnAverage.setCellValueFactory(new PropertyValueFactory<StudentModel, Double>("Average"));
        columnYear.setCellValueFactory(new PropertyValueFactory<StudentModel, Integer>("Year"));

        tableDb.setItems(studentsList);
    }

    @Override
    public void initialize(URL url, ResourceBundle rb){
        showStudents();
    }

    @FXML
    void Add(ActionEvent event) {
        ObservableList<StudentModel> studentsList = getStudents();
        String query ="INSERT INTO students VALUES (" + (studentsList.get(studentsList.size() - 1).getId() + 1) +  ",'"
                + textName.getText() + "','"
                + textSurname.getText() + "','"
                + textIndex.getText() + "','"
                + textAddress.getText() + "','"
                + textFaculty.getText() + "',"
                + textAverage.getText() + ","
                + textYear.getText() + ")";
        System.out.println(query);
        executeQuery(query);
        showStudents();
    }

    private void executeQuery(String query) {
        Connection conn = getConnection();
        Statement st;

        try {
            st = conn.createStatement();
            st.executeUpdate(query);
        }catch (Exception ex){
            ex.printStackTrace();
        }
    }

    @FXML
    void Delete(ActionEvent event) {
        if(student != null){
            String query = "DELETE FROM students WHERE Id = " + student.getId();
            System.out.println(query);
            executeQuery(query);
            showStudents();
        }
    }

    @FXML
    void Update(ActionEvent event) {
        if (student != null) {
            String query = "UPDATE students SET " +
                    "Name='" + textName.getText() + "'," +
                    "Surname='" + textSurname.getText() + "'," +
                    "IndexNumber='" + textIndex.getText() + "'," +
                    "Address='" + textAddress.getText() + "'," +
                    "Faculty='" + textFaculty.getText() + "'," +
                    "Average=" + textAverage.getText() + "," +
                    "Year=" + textYear.getText() +
                    " WHERE Id =" + student.getId() + ";";
            System.out.println(query);
            executeQuery(query);
            showStudents();
        }
    }

    @FXML
    StudentModel getSelected(){
        student = tableDb.getSelectionModel().getSelectedItem();
        if(student!= null) {
            textName.setText(student.getName());
            textSurname.setText(student.getSurname());
            textIndex.setText(student.getIndex());
            textAddress.setText(student.getAddress());
            textFaculty.setText(student.getFaculty());
            textAverage.setText(String.valueOf(student.getAverage()));
            textYear.setText(String.valueOf(student.getYear()));
        }
        return student;
    }



}