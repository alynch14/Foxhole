# Foxhole

Fantastical adventure about a fox destined to save the world from the terrors of the modern age.

# Project Setup

There are two important components to collaboration on this project: Git and Github. In order to download the project, save changes, and update this remote repository, you will need to download and install Git from this site: https://git-scm.com/

**Additionally, you will need to make sure that you have Unity version 20.1.1f1 installed in order to edit the project.**

## Installing Git
There are **TWO** ways of using Git. If you are familiar with using a terminal, then you can use git via command line (Documentation: https://git-scm.com/doc). The other option is by using one of the GUI options (found here: https://git-scm.com/downloads/guis). Adam has personally used the Github desktop GUI for Unity projects in the past and recommends that one to anyone that is not comfortable with using the software via command line.

Follow this tutorial on setting up Git on your computer after you finish installing it: https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup

**Make sure to set up your gitconfig for Git after installation. This will allow Git to tell who you are and allow you to access the project from the Github repository. Otherwise, you will be denied access.**

## Cloning Project
Once git is installed, you will have to clone this remote repository down to your local machine. Using the terminal, you will want to navigate to the directory you wish to store this project on your computer, and then execute the `git clone` command. This can be done by executing the following command:

```
cd Directory/That/Will/Contain/Project
git clone https://github.com/alynch14/Foxhole.git
```

## Committing Your Changes and Updating the Remote Repo

Whenever you want to update the project on the remote with your changes, you will need to commit them via Git. Once you are satisfied with your changes, you will have to 'add' your changes using `git add path/to/changed/file(s)`, you will then 'commit' the changes to the project using `git commit -m "Message detailing a short summary of what you changed"`, and finally you can 'push' your changes to the remote repository using `git push origin yourBranchName`

## Project structure

**Subject to change in the case that we come up with a better way to handle alpha and beta releases**

Everytime you are working on a new task, you need to make a new branch off of our 'development' branch. This way, we can make sure that the code on our 'master' branch is up to date with the **most stable build**. From the master branch, changing to the development branch and creating your own feature branch can be done by executing these commands:

```
git checkout development
git branch feature/NameOfTask
git checkout feature/NameOfTask
```

When your task is complete, you will push your changes to your feature branch on the remote repository and create a Merge Request to merge your feature branch into the development branch. Once we have accumulated enough changes in the development branch and have made sure that the branch is free from any major bugs, we will merge the development branch into master for a release.

The following will be the structure of our project:

--master
     \
      development
              \
               feature

## Conflicts 

Conflicts with Unity projects can be a pain, primarily when they are in either .meta or .yml files. To avoid this, we should make sure that only one person is working on an individual prefab or scene at a time. Additionally, when you are ready to commit your changes to the repo, make sure to close down the Unity editor if you have edited any scenes or settings so that the Unity Engine closes those files before they are committed. This will prevent issues later on with merge conflicts for any non-script files in our project.
