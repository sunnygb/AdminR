#ifndef BST_H
#define BST_H
#include <iostream>
#include <QGraphicsView>
#include <QTextStream>
#include <QProcess>
#include "ui_mainwindow.h"

using namespace std;

struct Node{
	Node *p;
	int key;
	Node *left;
	Node *right;
};

class BST
{
	public:
		void init(QGraphicsScene* scene, QGraphicsView* view);
		void insert(int a);

		QString preorderWalk();
		QString postorderWalk();

		
		
		QString inorderWalk();

		void deleteNode(int val);
		void deleteNode(Node* p);
		void show(QLabel *label);

		int countNodes();
		int countLevels();
		int countLeftNodes();
		Node* findElem(int val);
	protected:
	private:
		int countNodes(Node* p);
		int countLevels(Node* p);
		int countLeftNodes(Node *p);

		void PreorderWalk(Node* p);
		void PostorderWalk(Node* p);
		void InorderWalk(Node* p);
		

		Node* findSuccessor(int val);

		QByteArray _prepareGraph();
		void _graphWalk(Node* p,  QTextStream* stream);
		Node* findElem(int val, Node* p);

		Node* _root;
		QString string;
		QGraphicsScene* _scene;
		QGraphicsView* _view;
};

#endif // BST_H
