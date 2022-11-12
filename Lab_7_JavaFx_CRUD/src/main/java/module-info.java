module com.example.lab_7_javafx_crud {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.lab_7_javafx_crud to javafx.fxml;
    exports com.example.lab_7_javafx_crud;
}