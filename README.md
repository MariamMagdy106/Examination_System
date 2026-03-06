# 📝 Examination Management System

A **console-based Examination Management System** built in **C#** demonstrating **core OOP concepts, generics, events & delegates, and file I/O**.  
This project simulates a real-world examination platform with multiple question types, automatic grading, and student notifications.

---

## 📑 Table of Contents

- [Features](#features)  
- [Technologies Used](#technologies-used)  
- [Getting Started](#getting-started)  
- [Usage](#usage)  
- [Design Decisions](#design-decisions)  
- [Sample Output](#sample-output)  

---

## 🚀 Features

- **Supports multiple question types**:  
  - True/False  
  - Choose One  
  - Choose All  

- **Handles Practice Exams and Final Exams**  

- **Automatic Exam Correction**  

- **File Logging**: Questions and exam results are saved to files  

- **Student Notification System**: Implemented using **events & delegates**  

- **Designed using OOP principles**:  
  - Inheritance  
  - Polymorphism  
  - Interfaces (`ICloneable`, `IComparable`)  
  - Abstract classes & virtual methods  

- **Generics**: Used for repository management  

- **Fully extensible**: Easily add new question types or exam behaviors  

---

## 🛠 Technologies Used

- **C# (.NET 7)**  
- **Console Application**  
- **File I/O** (`StreamWriter`)  
- **Arrays & Generics**  
- **Delegates & Events**  

---

## ⚙️ Getting Started

### Prerequisites

- .NET SDK (6.0 / 7.0) installed  
- IDE: Visual Studio or VS Code  

### Build & Run

1. Clone the repository:  

 git clone https://github.com/<username>/ExaminationSystem.git

## 🎮 Usage

Follow these steps to run and interact with the Examination Management System:

1. **Create a Subject**  

2. **Create Students** and enroll them in the subject  

3. **Create Exams**:  
   - One Practice Exam  
   - One Final Exam  

4. **Add Questions** to exams  

5. **Select Exam Type**:  
   - `1` – Practice  
   - `2` – Final  

6. **Start Exam** – triggers notifications automatically  

7. **Answer Questions**  

8. **Finish Exam** – results are automatically persisted to a file: <SubjectName>_Results.txt

-----------------------------------------------------------

## 🧩 Design Decisions
- Abstract Base Classes (Question, Exam) provide extensibility
- Events & Delegates notify students automatically when exams start
- AnswerList uses arrays internally to follow project requirements
- Cloneable implemented for Question and Exam to allow deep copying
- File Logging ensures a permanent record of questions and exam results
  

## 📊 Sample OutPut

### 💻 Example Of How Exam Results Saved

--- Practice Exam: Programming 101 ---

Q1: C# is a statically typed language? (Marks: 5)

Student Answer: True

Correct Answer: True

Marks Earned: 5

------------------------------------

Q1: Which Language developed By Microsoft? (Marks: 5)

Student Answer: C#

Correct Answer: C#

Marks Earned: 5

Final Grade: 10 / 10

Results saved to Programming101_Results.txt

### 💻 Example Question Flow

--- Practice Exam: Programming 101 ---

Q1: C# is a statically typed language? (Marks: 5)
1. True
2. False
Enter Answer Id: 1

Q2: Which language is primarily used for Android development? (Marks: 5)
1. C#
2. Java
3. Python
Enter Answer Id: 2

Q3: Which are programming languages? (Marks: 5)
1. Python
2. HTML
3. Java
4. CSS
Enter Answer Ids separated by comma: 1,3

