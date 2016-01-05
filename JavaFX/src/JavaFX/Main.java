package JavaFX;


import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.File;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public class Main extends Application {
    private Stage primeryStage;

    public static void main(String[] args) {
        try {
            String fileUrl = new File("src/JavaFX/Database/Database.accdb").toURI().toURL().getPath();
            Connection conn = DriverManager.getConnection("jdbc:ucanaccess:/" + fileUrl);
            Statement statement = conn.createStatement();
            System.out.println("DataBase Connedcted Succesfully");
            launch(args);

        } catch (Exception e) {
            e.printStackTrace();
        }


    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        this.primeryStage =primaryStage;
        mainWindow( );


    }

    public void mainWindow() {
        try {

            Parent root = FXMLLoader.load(getClass().getResource("Views/JavaFX.fxml"));
            Scene scene = new Scene(root);
            primeryStage.setScene(scene);
            primeryStage.show();

        } catch (Exception e) {
            e.printStackTrace();
        }


    }
}