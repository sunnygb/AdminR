#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "BST.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
	Q_OBJECT

public:
	explicit MainWindow(QWidget *parent = 0);
	~MainWindow();

private slots:
	void on_pushButton_clicked();

	void on_addBtn_clicked();

	void on_searchBtn_clicked();

	void on_delBtn_clicked();

	void on_preBtn_clicked();

	void on_inBtn_clicked();

	void on_postBtn_clicked();

private:
	Ui::MainWindow *ui;
	BST *bst;
};

#endif // MAINWINDOW_H
