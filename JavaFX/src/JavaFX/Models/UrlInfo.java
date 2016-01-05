package JavaFX.Models;

public class UrlInfo{
    private String url;
    private String headline;
    private String summeries;


    public UrlInfo(String url, String summeries, String headline) {
        this.url = url;
        this.summeries = summeries;
        this.headline = headline;
    }

    public UrlInfo(String url) {
        this.url = url;
    }
public UrlInfo ()
{

}

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getHeadline() {
        return headline;
    }

    public void setHeadline(String headline) {
        this.headline = headline;
    }

    public String getSummeries() {
        return summeries;
    }

    public void setSummeries(String summeries) {
        this.summeries = summeries;
    }
}