package JavaFX.Models;

import java.io.File;
import java.io.InputStream;
import java.net.URL;
import java.sql.Statement;
import java.util.Properties;

/**
 * Created by Sunny on 1/3/2016.
 */
public  class Model {

    public static Properties pathProperties = null;

    static {
        pathProperties = new Properties();
        String pathPropertiesFile = "Models/Database.accdb";
        InputStream url = pathProperties.getClass().getResourceAsStream(pathPropertiesFile);
    }
        //URL url = getClass().getResource("Models/Database.accdb");

    }


