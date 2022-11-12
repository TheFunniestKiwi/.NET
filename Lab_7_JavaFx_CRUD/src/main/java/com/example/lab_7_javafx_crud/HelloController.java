package com.example.lab_7_javafx_crud;

import javafx.fxml.FXML;

import javafx.event.ActionEvent;
import javafx.scene.control.Button;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;

public class HelloController {
    Connection con;
    PreparedStatement pst;
    in MyIndex;
    int id;

    @FXML
    private Button btnAdd;

    @FXML
    private Button btnDelete;

    @FXML
    private Button btnUpdate;

    @FXML
    private TableColumn<?, ?> columnName;

    @FXML
    private TableColumn<?, ?> columnAddress;

    @FXML
    private TableColumn<?, ?> columnAverage;

    @FXML
    private TableColumn<?, ?> columnFaculty;

    @FXML
    private TableColumn<?, ?> columnID;

    @FXML
    private TableColumn<?, ?> columnIndex;

    @FXML
    private TableColumn<?, ?> columnSurname;

    @FXML
    private TableColumn<?, ?> columnYear;

    @FXML
    private TableView<?> tableDb;

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

    @FXML
    void Add(ActionEvent event) {

    }

    @FXML
    void Delete(ActionEvent event) {

    }

    @FXML
    void Update(ActionEvent event) {

    }

}