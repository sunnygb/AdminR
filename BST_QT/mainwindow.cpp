#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "BST.h"
using namespace std;


MainWindow::MainWindow(QWidget *parent) :
	QMainWindow(parent),
	ui(new Ui::MainWindow)
{
	ui->setupUi(this);
	

	QIntValidator *v = new QIntValidator(1, 999);
	ui->addLabel->setValidator(v);
	ui->delLabel->setValidator(v);
	ui->searchLabel->setValidator(v);



	BST* a = new BST();
	this->bst = a;

	

}

MainWindow::~MainWindow()
{
	delete ui;
}

void MainWindow::on_pushButton_clicked()
{
	
	
	



		BST *a = this->bst;
		a->insert(7);
		a->insert(6);
		a->insert(10);
		a->insert(3);
		a->insert(4);
		a->insert(5);
		a->insert(8);
		a->insert(999);
		/*a->insert(9);
		a->insert(99);
		a->insert(100);
		a->insert(50);
		a->insert(110);
		a->insert(150);
		a->insert(19);
		a->insert(99);
		a->insert(101);
		a->insert(21);
		a->insert(91);*/


			 /*  cout << "Number of nodes which have only left child: " << a->countLeftNodes() << endl;
			   cout << "Tree height: " << a->countLevels() << endl;
			   cout << "Number of nodes: " << a->countNodes() << endl;
			   cout << "Find element: " << a->findElem(12) << endl;
			   a->preorderWalk();
			   a->inorderWalk();
			   a->postorderWalk();*/
		a->show(this->ui->graphLabel);
		//this->ui->graphLabel->clear();
		//BST* bst = new BST();
		//this->bst = bst;
	
	
}

void MainWindow::on_addBtn_clicked()
{
	int data = ui->addLabel->text().toInt();
	
	if (ui->addLabel->text().isEmpty())
	{

		this->ui->addLabel->clear();
		return;
	}
	
	if (this->bst->findElem(data)==NULL)
	{


		this->ui->msgLabel->setText("Node Added Successfully...!!!");
		this->bst->insert(data);
		this->bst->show(ui->graphLabel);
		this->ui->addLabel->clear();
	}
	else
	{
		this->ui->msgLabel->setText("Node Already Present...!!!");
		this->ui->addLabel->clear();
	}
	
}

void MainWindow::on_searchBtn_clicked()
{
	int data = ui->searchLabel->text().toInt();
	if (ui->searchLabel->text().isEmpty())
	{

		this->ui->addLabel->clear();
		return;
	}
	if (this->bst->findElem(data) == NULL)
	{

		this->ui->msgLabel->setText("Node Not Found In The Tree");
		this->ui->searchLabel->clear();

		
	}
	else
	{
		this->ui->msgLabel->setText("Node Is Present In The Tree");
		this->ui->searchLabel->clear();
		
	}
	
}

void MainWindow::on_delBtn_clicked()
{
	int data = ui->delLabel->text().toInt();
	if (ui->delLabel->text().isEmpty())
	{

		this->ui->addLabel->clear();
		return;
	}
	
	if (this->bst->findElem(data) == NULL)
	{

		this->ui->msgLabel->setText("Node Not Found In The Tree");
		this->ui->delLabel->clear();


	}
	else
	{
		this->bst->deleteNode(data);
		this->bst->show(ui->graphLabel);
		this->ui->msgLabel->setText("Node Deleted Successfully...!!");
		this->ui->delLabel->clear();

	}
}

void MainWindow::on_preBtn_clicked()
{
	ui->msgLabel->setText(bst->preorderWalk());
}

void MainWindow::on_inBtn_clicked()
{
	ui->msgLabel->setText(bst->inorderWalk());	
}

void MainWindow::on_postBtn_clicked()
{
	ui->msgLabel->setText(bst->postorderWalk());
}
