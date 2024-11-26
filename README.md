# **BitHeap Automation Project**

This project is a **C# automation framework** designed to test various functionalities of the BitHeap website using the **Page Object Model (POM)** and **NUnit** for test execution. The framework covers core workflows such as login, blog interaction, contact form submission, and shop navigation. Screenshots are captured during tests for detailed analysis.

---

### **Features**

- **Home Page**: Automates navigation to the home page and validates key elements.
- **Blog Page**: Tests blog interactions, including viewing and liking posts.
- **Login Page**: Automates user login and verifies authentication workflows.
- **Contact Us Page**: Tests contact form submission and validates user feedback handling.
- **Shop Page**: Automates product selection, search, and cart management.
- **My Account Page**: Validates user dashboard functionalities like order history and account settings.

---

### **Tools and Technologies**

- **Framework**: Playwright with C#
- **Test Runner**: NUnit
- **Browser Automation**: Chromium-based browsers
- **Screenshots**: Captured for every test in the `Screenshots` folder

---

### **Setup and Installation**

1. **Install .NET SDK**  
   Download and install .NET SDK (6.0 or higher) from [Microsoft .NET](https://dotnet.microsoft.com/).
2. **Install Node.js**  
   Download and install Node.js from [Node.js](https://nodejs.org/).
3. **Install Playwright**  
   Use Node.js to install Playwright: npm install -g playwright
4. **Download Browsers**  
   Install Playwright-supported browsers: npx playwright install

---

### **Usage**

1. **Build the Project**: dotnet build

2. **Run the Tests**:  
   Execute the test suite using NUnit: dotnet test

3. **View Test Results**:  
   Test results are displayed in the console, and screenshots are saved in the `Screenshots/` folder.

---

### **Note**

1. Ensure that the required environment variables (`USERNAME`, `PASSWORD`) are set before running the tests.  
2. If you encounter browser-related issues, re-run the Playwright browser installation command: npx playwright install
3. Screenshots are automatically captured for debugging purposes after every test.  
4. Use the **Page Object Model** structure to extend or add additional test cases efficiently.
