/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.6.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QFrame>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QPushButton *infoBtn;
    QPushButton *pushButton_4;
    QPushButton *pushButton;
    QLabel *label_3;
    QFrame *frame;
    QLineEdit *searchLabel;
    QPushButton *addBtn;
    QPushButton *searchBtn;
    QPushButton *delBtn;
    QLineEdit *delLabel;
    QLineEdit *addLabel;
    QLineEdit *msgLabel;
    QFrame *line;
    QPushButton *addBtn_2;
    QFrame *frame_2;
    QPushButton *preBtn;
    QPushButton *inBtn;
    QPushButton *postBtn;
    QLabel *graphLabel;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(437, 674);
        QSizePolicy sizePolicy(QSizePolicy::Preferred, QSizePolicy::Preferred);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(MainWindow->sizePolicy().hasHeightForWidth());
        MainWindow->setSizePolicy(sizePolicy);
        MainWindow->setMinimumSize(QSize(437, 674));
        MainWindow->setMaximumSize(QSize(437, 674));
        MainWindow->setBaseSize(QSize(10240, 8000));
        QFont font;
        font.setKerning(true);
        font.setStyleStrategy(QFont::PreferAntialias);
        MainWindow->setFont(font);
        MainWindow->setWindowOpacity(1);
        MainWindow->setLayoutDirection(Qt::LeftToRight);
        MainWindow->setDocumentMode(false);
        MainWindow->setTabShape(QTabWidget::Rounded);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        infoBtn = new QPushButton(centralWidget);
        infoBtn->setObjectName(QStringLiteral("infoBtn"));
        infoBtn->setGeometry(QRect(110, 20, 41, 41));
        infoBtn->setCursor(QCursor(Qt::PointingHandCursor));
        infoBtn->setMouseTracking(true);
        infoBtn->setAutoFillBackground(false);
        infoBtn->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon;
        icon.addFile(QStringLiteral(":/info.png"), QSize(), QIcon::Normal, QIcon::Off);
        infoBtn->setIcon(icon);
        infoBtn->setIconSize(QSize(30, 40));
        infoBtn->setCheckable(true);
        infoBtn->setAutoRepeat(true);
        infoBtn->setAutoExclusive(true);
        pushButton_4 = new QPushButton(centralWidget);
        pushButton_4->setObjectName(QStringLiteral("pushButton_4"));
        pushButton_4->setGeometry(QRect(-10, -10, 81, 81));
        pushButton_4->setAutoFillBackground(false);
        pushButton_4->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon1;
        icon1.addFile(QStringLiteral(":/menu.png"), QSize(), QIcon::Normal, QIcon::Off);
        pushButton_4->setIcon(icon1);
        pushButton_4->setIconSize(QSize(60, 60));
        pushButton_4->setCheckable(true);
        pushButton_4->setAutoRepeat(true);
        pushButton_4->setAutoExclusive(true);
        pushButton = new QPushButton(centralWidget);
        pushButton->setObjectName(QStringLiteral("pushButton"));
        pushButton->setGeometry(QRect(70, 20, 41, 41));
        pushButton->setCursor(QCursor(Qt::PointingHandCursor));
        pushButton->setMouseTracking(true);
        pushButton->setAutoFillBackground(false);
        pushButton->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon2;
        icon2.addFile(QStringLiteral(":/TV_stand.png"), QSize(), QIcon::Normal, QIcon::Off);
        pushButton->setIcon(icon2);
        pushButton->setIconSize(QSize(30, 40));
        pushButton->setCheckable(true);
        pushButton->setAutoRepeat(true);
        pushButton->setAutoExclusive(true);
        label_3 = new QLabel(centralWidget);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(190, 0, 251, 71));
        label_3->setPixmap(QPixmap(QString::fromUtf8(":/coollogo_com-77234039 (1).png")));
        label_3->setScaledContents(true);
        frame = new QFrame(centralWidget);
        frame->setObjectName(QStringLiteral("frame"));
        frame->setGeometry(QRect(-1, 580, 441, 101));
        frame->setStyleSheet(QLatin1String("\n"
"background-color: rgb(194, 29, 79);"));
        frame->setFrameShape(QFrame::StyledPanel);
        frame->setFrameShadow(QFrame::Raised);
        searchLabel = new QLineEdit(frame);
        searchLabel->setObjectName(QStringLiteral("searchLabel"));
        searchLabel->setEnabled(true);
        searchLabel->setGeometry(QRect(200, 10, 71, 41));
        QFont font1;
        font1.setFamily(QStringLiteral("Lucida Calligraphy"));
        font1.setPointSize(14);
        font1.setBold(true);
        font1.setWeight(75);
        searchLabel->setFont(font1);
        searchLabel->setMouseTracking(false);
        searchLabel->setFocusPolicy(Qt::StrongFocus);
        searchLabel->setAcceptDrops(true);
        searchLabel->setStyleSheet(QLatin1String("background-color:rgb(56, 162, 255);\n"
"color:white;\n"
" border-radius: 10px;"));
        searchLabel->setInputMethodHints(Qt::ImhDigitsOnly);
        searchLabel->setFrame(false);
        searchLabel->setAlignment(Qt::AlignCenter);
        addBtn = new QPushButton(frame);
        addBtn->setObjectName(QStringLiteral("addBtn"));
        addBtn->setGeometry(QRect(10, 10, 41, 41));
        addBtn->setCursor(QCursor(Qt::PointingHandCursor));
        addBtn->setMouseTracking(true);
        addBtn->setAutoFillBackground(false);
        addBtn->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon3;
        icon3.addFile(QStringLiteral(":/plus.png"), QSize(), QIcon::Normal, QIcon::Off);
        addBtn->setIcon(icon3);
        addBtn->setIconSize(QSize(40, 40));
        addBtn->setCheckable(true);
        addBtn->setAutoRepeat(true);
        addBtn->setAutoExclusive(true);
        searchBtn = new QPushButton(frame);
        searchBtn->setObjectName(QStringLiteral("searchBtn"));
        searchBtn->setGeometry(QRect(150, 10, 41, 41));
        searchBtn->setCursor(QCursor(Qt::PointingHandCursor));
        searchBtn->setMouseTracking(true);
        searchBtn->setAutoFillBackground(false);
        searchBtn->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon4;
        icon4.addFile(QStringLiteral(":/pan.png"), QSize(), QIcon::Normal, QIcon::Off);
        searchBtn->setIcon(icon4);
        searchBtn->setIconSize(QSize(40, 40));
        searchBtn->setCheckable(true);
        searchBtn->setAutoRepeat(true);
        searchBtn->setAutoExclusive(true);
        delBtn = new QPushButton(frame);
        delBtn->setObjectName(QStringLiteral("delBtn"));
        delBtn->setGeometry(QRect(310, 10, 41, 41));
        delBtn->setCursor(QCursor(Qt::PointingHandCursor));
        delBtn->setMouseTracking(true);
        delBtn->setAutoFillBackground(false);
        delBtn->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon5;
        icon5.addFile(QStringLiteral(":/trash.png"), QSize(), QIcon::Normal, QIcon::Off);
        delBtn->setIcon(icon5);
        delBtn->setIconSize(QSize(40, 40));
        delBtn->setCheckable(true);
        delBtn->setAutoRepeat(true);
        delBtn->setAutoExclusive(true);
        delLabel = new QLineEdit(frame);
        delLabel->setObjectName(QStringLiteral("delLabel"));
        delLabel->setEnabled(true);
        delLabel->setGeometry(QRect(360, 10, 71, 41));
        delLabel->setFont(font1);
        delLabel->setMouseTracking(false);
        delLabel->setFocusPolicy(Qt::StrongFocus);
        delLabel->setAcceptDrops(true);
        delLabel->setStyleSheet(QLatin1String("background-color:rgb(56, 162, 255);\n"
"\n"
"\n"
"color:white;\n"
" border-radius: 10px;"));
        delLabel->setInputMethodHints(Qt::ImhDigitsOnly);
        delLabel->setFrame(false);
        delLabel->setAlignment(Qt::AlignCenter);
        addLabel = new QLineEdit(frame);
        addLabel->setObjectName(QStringLiteral("addLabel"));
        addLabel->setEnabled(true);
        addLabel->setGeometry(QRect(60, 10, 61, 41));
        QFont font2;
        font2.setFamily(QStringLiteral("Lucida Calligraphy"));
        font2.setPointSize(14);
        font2.setBold(true);
        font2.setWeight(75);
        font2.setStyleStrategy(QFont::PreferAntialias);
        addLabel->setFont(font2);
        addLabel->setMouseTracking(false);
        addLabel->setFocusPolicy(Qt::StrongFocus);
        addLabel->setAcceptDrops(true);
        addLabel->setStyleSheet(QLatin1String("background-color:rgb(56, 162, 255);\n"
"color:white;\n"
"border-radius: 10px;"));
        addLabel->setInputMethodHints(Qt::ImhDigitsOnly);
        addLabel->setMaxLength(999);
        addLabel->setFrame(false);
        addLabel->setAlignment(Qt::AlignCenter);
        msgLabel = new QLineEdit(frame);
        msgLabel->setObjectName(QStringLiteral("msgLabel"));
        msgLabel->setEnabled(true);
        msgLabel->setGeometry(QRect(40, 60, 391, 31));
        QFont font3;
        font3.setFamily(QStringLiteral("Comic Sans MS"));
        font3.setPointSize(10);
        font3.setBold(true);
        font3.setItalic(false);
        font3.setUnderline(false);
        font3.setWeight(75);
        font3.setStrikeOut(false);
        font3.setKerning(true);
        font3.setStyleStrategy(QFont::PreferAntialias);
        msgLabel->setFont(font3);
        msgLabel->setCursor(QCursor(Qt::ArrowCursor));
        msgLabel->setMouseTracking(false);
        msgLabel->setFocusPolicy(Qt::NoFocus);
        msgLabel->setAcceptDrops(true);
        msgLabel->setStyleSheet(QLatin1String("background-color:transparent;\n"
"border-color: rgb(24, 35, 255);\n"
"color:rgb(255, 255, 24)"));
        msgLabel->setInputMethodHints(Qt::ImhDigitsOnly);
        msgLabel->setFrame(false);
        msgLabel->setAlignment(Qt::AlignCenter);
        line = new QFrame(frame);
        line->setObjectName(QStringLiteral("line"));
        line->setGeometry(QRect(10, 53, 421, 16));
        line->setStyleSheet(QStringLiteral("color: rgb(255, 255, 255);"));
        line->setFrameShadow(QFrame::Plain);
        line->setFrameShape(QFrame::HLine);
        addBtn_2 = new QPushButton(frame);
        addBtn_2->setObjectName(QStringLiteral("addBtn_2"));
        addBtn_2->setEnabled(true);
        addBtn_2->setGeometry(QRect(-10, 53, 71, 51));
        addBtn_2->setCursor(QCursor(Qt::ArrowCursor));
        addBtn_2->setMouseTracking(true);
        addBtn_2->setAutoFillBackground(false);
        addBtn_2->setStyleSheet(QStringLiteral("background-color:transparent;"));
        QIcon icon6;
        icon6.addFile(QStringLiteral(":/futuro_icons_64px_489.png"), QSize(), QIcon::Normal, QIcon::Off);
        addBtn_2->setIcon(icon6);
        addBtn_2->setIconSize(QSize(30, 26));
        addBtn_2->setCheckable(true);
        addBtn_2->setAutoRepeat(true);
        addBtn_2->setAutoExclusive(true);
        searchLabel->raise();
        addBtn->raise();
        searchBtn->raise();
        delBtn->raise();
        delLabel->raise();
        addLabel->raise();
        line->raise();
        msgLabel->raise();
        addBtn_2->raise();
        frame_2 = new QFrame(centralWidget);
        frame_2->setObjectName(QStringLiteral("frame_2"));
        frame_2->setGeometry(QRect(10, 0, 441, 61));
        frame_2->setStyleSheet(QLatin1String("background-color: rgb(90, 48, 118);\n"
"\n"
""));
        frame_2->setFrameShape(QFrame::StyledPanel);
        frame_2->setFrameShadow(QFrame::Raised);
        preBtn = new QPushButton(frame_2);
        preBtn->setObjectName(QStringLiteral("preBtn"));
        preBtn->setGeometry(QRect(60, 2, 20, 20));
        QFont font4;
        font4.setFamily(QStringLiteral("Rockwell Extra Bold"));
        font4.setPointSize(7);
        font4.setBold(false);
        font4.setItalic(false);
        font4.setWeight(50);
        preBtn->setFont(font4);
        preBtn->setCursor(QCursor(Qt::PointingHandCursor));
        preBtn->setMouseTracking(true);
        preBtn->setAutoFillBackground(false);
        preBtn->setStyleSheet(QLatin1String("background-color:rgb(255, 98, 19);\n"
"border-radius:10px;\n"
"color: white;\n"
""));
        preBtn->setIconSize(QSize(40, 40));
        preBtn->setCheckable(true);
        preBtn->setAutoRepeat(true);
        preBtn->setAutoExclusive(true);
        inBtn = new QPushButton(frame_2);
        inBtn->setObjectName(QStringLiteral("inBtn"));
        inBtn->setGeometry(QRect(90, 2, 20, 20));
        inBtn->setFont(font4);
        inBtn->setCursor(QCursor(Qt::PointingHandCursor));
        inBtn->setMouseTracking(true);
        inBtn->setAutoFillBackground(false);
        inBtn->setStyleSheet(QLatin1String("background-color:rgb(7, 148, 0);\n"
"border-radius:10px;\n"
"color: white;\n"
""));
        inBtn->setIconSize(QSize(40, 40));
        inBtn->setCheckable(true);
        inBtn->setAutoRepeat(true);
        inBtn->setAutoExclusive(true);
        postBtn = new QPushButton(frame_2);
        postBtn->setObjectName(QStringLiteral("postBtn"));
        postBtn->setGeometry(QRect(119, 2, 20, 20));
        postBtn->setFont(font4);
        postBtn->setCursor(QCursor(Qt::PointingHandCursor));
        postBtn->setMouseTracking(true);
        postBtn->setAutoFillBackground(false);
        postBtn->setStyleSheet(QLatin1String("background-color:rgb(3, 3, 3);\n"
"border-radius:10px;\n"
"color: white;\n"
""));
        postBtn->setIconSize(QSize(40, 40));
        postBtn->setCheckable(true);
        postBtn->setAutoRepeat(true);
        postBtn->setAutoExclusive(true);
        graphLabel = new QLabel(centralWidget);
        graphLabel->setObjectName(QStringLiteral("graphLabel"));
        graphLabel->setGeometry(QRect(0, 60, 441, 521));
        QSizePolicy sizePolicy1(QSizePolicy::Expanding, QSizePolicy::Expanding);
        sizePolicy1.setHorizontalStretch(0);
        sizePolicy1.setVerticalStretch(0);
        sizePolicy1.setHeightForWidth(graphLabel->sizePolicy().hasHeightForWidth());
        graphLabel->setSizePolicy(sizePolicy1);
        QFont font5;
        font5.setStyleStrategy(QFont::PreferAntialias);
        graphLabel->setFont(font5);
        graphLabel->setStyleSheet(QStringLiteral("background-color: rgb(8, 8, 8);"));
        MainWindow->setCentralWidget(centralWidget);
        frame_2->raise();
        frame->raise();
        infoBtn->raise();
        pushButton_4->raise();
        pushButton->raise();
        label_3->raise();
        graphLabel->raise();

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", 0));
        infoBtn->setText(QString());
        pushButton_4->setText(QString());
        pushButton->setText(QString());
        label_3->setText(QString());
        searchLabel->setText(QString());
        addBtn->setText(QString());
        searchBtn->setText(QString());
        delBtn->setText(QString());
        delLabel->setText(QString());
        addLabel->setText(QString());
        msgLabel->setText(QApplication::translate("MainWindow", "Graphical Representation of Binary Search Tree", 0));
        addBtn_2->setText(QString());
        preBtn->setText(QApplication::translate("MainWindow", "P", 0));
        inBtn->setText(QApplication::translate("MainWindow", "I", 0));
        postBtn->setText(QApplication::translate("MainWindow", "P", 0));
        graphLabel->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
