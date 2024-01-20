using System;
using System.IO;

class Program
{
    static void Main()
    {
        string name, nameToCheck = "o", pass, ro, p;
        string nam, pas, j = "0", cusChoice = "0";
        string inCode;
        string vCode = "admin"; // admin verification code

        int userCount = 0, r = 0;
        int totalProducts = 5;
        int reviewNo = 0;

        string[] userName = new string[100];
        string[] userPass = new string[100];
        string[] role = new string[100];
        string[] productName = new string[100];
        string[] productId = new string[100];
        string[] price = new string[100];
        string[] Review = new string[100];

        productDetails(productId, productName, price, totalProducts);
        string line;
        int field;
        loadUserData(userName, userPass, role, ref userCount);
        loadProductData(productId, productName, price, ref totalProducts);

        while (true) // outer most while loop
        {
            Console.Clear();
            welcomeHeader();
            header();
            Console.WriteLine("\t\tEnter your choice:     1- Sign Up     2- Sign In      3- Exit");
            string choice = Console.ReadLine();

            if (choice == "1") // signUp
            {
                Console.Clear();
                signUpHeader();

                while (true) /*check if user name already exists*/
                {
                    Console.Write("Enter Username: ");
                    name = getName();
                    if (nameCheck(userName, userCount, name, ro))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This username already exists. Try again.");
                        Console.ResetColor();
                    }
                }

                while (true) // password validation
                {
                    p = getPass();
                    if (passValid(p))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid password");
                        Console.ResetColor();
                    }
                }

                Console.Write("Enter your Role (Customer, Worker, or Admin): ");
                ro = Console.ReadLine();

                role[userCount] = ro;
                userName[userCount] = name;
                userPass[userCount] = p;
                Console.WriteLine("Successfully signed up");
                userCount++;
                writeData(userName, userPass, role, userCount);
                Console.ReadKey();
            }
            else if (choice == "2") // signIn
            {
                Console.Clear();
                signInHeader();

                Console.Write("Enter Username: ");
                nam = Console.ReadLine();
                Console.Write("Enter Password: ");
                pas = Console.ReadLine();

                int a = IDreturn(userName, userPass, role, userCount, nam, pas);
                j = role[a];

                if (j == "customer" || j == "Customer" || j == "CUSTOMER")
                {
                    while (j == "1")
                    {
                        cusChoice = displayCusMenu(productName, price);
                        if (cusChoice == "1")
                        {
                            while (true)
                            {
                                Console.Clear();
                                collectionHeader();
                                viewCollection(totalProducts, userPass, userCount, productId, productName, price);
                                Console.Write("Enter 0 to go back: ");
                                string exit = Console.ReadLine();
                                if (exit == "0")
                                    break;
                            }
                        }
                        else if (cusChoice == "2")
                        {
                            placeOrder(productId, productName, price);
                        }
                        else if (cusChoice == "3")
                        {
                            customerReview(Review, reviewNo, ref r);
                        }
                        else if (cusChoice == "4")
                        {
                            changePass(userName, userPass, userCount, nameToCheck, role);
                            writeData(userName, userPass, role, userCount);
                        }
                        else if (cusChoice == "5")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("THE OPTION YOU ENTERED IS NOT AVAILABLE\nPress any key to continue");
                            Console.ReadKey();
                        }
                    }
                }
                else if (j == "worker" || j == "Worker")
                {
                    while (true)
                    {
                        string workerChoice = displayWorkerMenu();
                        if (workerChoice == "1")
                        {
                            deleteProduct(totalProducts, productId, productName, price);
                        }
                        if (workerChoice == "2")
                        {
                            while (true)
                            {
                                Console.Clear();
                                collectionHeader();
                                char ex;
                                viewCollection(totalProducts, userPass, userCount, productId, productName, price);
                                Console.Write("Enter 0 to go back: ");
                                ex = Console.ReadKey().KeyChar;
                                if (ex == '0')
                                    break;
                            }
                        }
                        if (workerChoice == "3")
                        {
                            cusDetail(userName, userPass, role, userCount);
                        }
                        if (workerChoice == "0")
                        {
                            break;
                        }
                    }
                }
                else if (j == "Admin" || j == "admin")
                {
                    Console.Write("Enter Verification Code: ");
                    inCode = Console.ReadLine();
                    if (ownerCheck(inCode, vCode))
                    {
                        adminHeader();
                        while (true)
                        {
                            string adminchoice = displayAdminMenu();
                            if (adminchoice == "1")
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    collectionHeader();
                                    char ex;
                                    viewCollection(totalProducts, userPass, userCount, productId, productName, price);
                                    Console.Write("Enter 0 to go back: ");
                                    ex = Console.ReadKey().KeyChar;
                                    if (ex == '0')
                                        break;
                                }
                            }
                            else if (adminchoice == "2")
                            {
                                deleteProduct(totalProducts, productId, productName, price);
                                writeProductData(productId, productName, price, totalProducts);
                            }
                            else if (adminchoice == "3")
                            {
                                ordersPlaced();
                            }
                            else if (adminchoice == "4")
                            {
                                Console.Clear();
                                workerDetailHeader();
                                workerDetail(userName, userPass, role, userCount);
                            }
                            else if (adminchoice == "5")
                            {
                                vCode = changeVerCode(vCode, inCode);
                            }
                            else if (adminchoice == "7")
                            {
                                addProduct(ref totalProducts, productId, productName, price);
                                writeProductData(productId, productName, price, totalProducts);
                            }
                            else if (adminchoice == "0")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option.");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Credentials! \nTRY AGAIN\n\nPress any key to continue");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t \" Invalid Credentials \" \nPress Enter key to Continue.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            else if (choice == "3") // exit
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
    



    // Function to get user input for name
    static string GetName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to get user input for password
    static string GetPass()
    {
        Console.Write("Enter your password (must be six to 14 characters long): ");
        string pass = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine(); // Move to the next line after Enter key is pressed
                break;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (pass.Length > 0)
                {
                    Console.Write("\b \b"); // Move the cursor back, erase the character, move back again
                    pass = pass.Substring(0, pass.Length - 1); // Remove the last character from the password
                }
            }
            else
            {
                pass += key.KeyChar; // Append the character to the password
                Console.Write('*'); // Display '*' for each character
            }
        }

        Console.WriteLine($"Password entered: {pass}");
        return pass;
    }

    // Function to check if the username already exists
    static bool NameCheck(string[] userName, int userCount, string username, string ro)
    {
        bool exists = false;

        for (int x = 0; x < userCount; x++)
        {
            if (username == userName[x])
            {
                exists = true;
                break;
            }
        }

        return !exists;
    }

    // Function to validate the password length
    static bool PassValid(string p)
    {
        int pLength = p.Length;
        return pLength > 5 && pLength < 15;
    }

    // Function to return the role based on the username and password
    static string RoleReturn(string[] userName, string[] userPass, string[] role, string nam, string p, int userCount)
    {
        string no = "noMatch";
        string r = no;

        for (int x = 0; x < userCount; x++)
        {
            if (nam == userName[x] && p == userPass[x])
            {
                r = role[x];
                break;
            }
        }

        return r;
    }

    // Function to return the index of the user based on the username and password
    static int IDReturn(string[] userName, string[] userPass, string[] role, int userCount, string nameToCheck, string passToCheck)
    {
        int r = -1;

        for (int x = 0; x < userCount; x++)
        {
            if (nameToCheck == userName[x] && passToCheck == userPass[x])
            {
                r = x;
                break;
            }
        }

        return r;
    }

    // Function to display the customer menu and return the user's choice
    static string DisplayCusMenu(string[] productName, string[] price)
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~~\n\n");
        Console.WriteLine("\t***CUSTOMER MENU***\n\n");
        Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~~\n\n\n");
        Console.WriteLine("\tEnter:\n");
        Console.WriteLine("         1 to view Collection");
        Console.WriteLine("         2 to place Order");
        Console.WriteLine("         3 to give Customer Review");
        Console.WriteLine("         4 to reset password");
        Console.WriteLine("         5 to EXIT\n\n");

        Console.ResetColor();
        Console.Write("         ");
        string viewChoice = Console.ReadLine();
        return viewChoice;
    }
    
    // Function to view the collection of products
    static void ViewCollection(int totalProducts, string[] userPass, int userCount, string[] productId, string[] productName, string[] price)
    {
        Console.Clear();
        CollectionHeader();
        Glasses();
        Console.WriteLine("Product ID\t\t\t\tProduct name\t\t\t\tProduct Price\n\n");

        for (int x = 0; x < totalProducts; x++)
        {
            Console.WriteLine($"{x}\t\t\t\t\t{productName[x]}\t\t\t\t\t{price[x]}");
        }

        Console.WriteLine($"\ntotal: {totalProducts}");
    }

    // Function to place an order
    static void PlaceOrder(string[] productId, string[] productName, string[] price)
    {
        while (true)
        {
            string discountCode = "0", orderChoice;
            int orderId;
            Console.Write("Enter the product ID (1 to 20): ");
            orderId = Convert.ToInt32(Console.ReadLine()) - 1;
            int k = orderId;

            Console.Write("Enter discount code (if you have any): ");
            discountCode = Console.ReadLine();
            int DPrice = Convert.ToInt32(price[k]);
            if (discountCode == "code1")
            {
                DPrice = DPrice / 2;
            }

            Console.WriteLine("Order Summary: ");
            Console.WriteLine($"Product Id: {orderId + 1}");
            Console.WriteLine($"Product Name: {productName[k]}");
            Console.WriteLine($"Product Price: {DPrice}");

            Console.Write("Enter 1 to Confirm your Order or 2 to exit: ");
            orderChoice = Console.ReadLine();

            if (orderChoice == "1")
            {
                Console.WriteLine("Your Order has been placed \nThank you!\n\n");
                orderCount++;
                Console.WriteLine($"Your order ID is: {orderCount}");
                Console.ReadKey();
                break;
            }

            if (orderChoice == "2")
            {
                break;
            }
        }
    }

    // Function to change the password
    static void ChangePass(string[] userName, string[] userPass, int userCount, string nameToCheck, string[] role)
    {
        string pass;
        string currentPass;
        string n;

        Console.Write("Enter your name: ");
        n = Console.ReadLine();
        Console.Write("Enter your current password: ");
        currentPass = Console.ReadLine();
        int idx = IDReturn(userName, userPass, role, userCount, n, currentPass);

        if (currentPass == userPass[idx])
        {
            while (true)
            {
                Console.Write("Enter New password: ");
                pass = Console.ReadLine();

                if (PassValid(pass))
                {
                    userPass[idx] = pass;
                    Console.WriteLine("Password updated successfully\nPress any key to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid password");
                    Console.ResetColor();
                }
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Password did not match.\nPress any key to continue.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

    // Function to delete a product
    static void DeleteProduct(int totalProducts, string[] productId, string[] productName, string[] price)
    {
        int found = 0;
        string t_id = "0";
        Console.Write("\n\n ENTER Product ID TO DELETE -> ");
        t_id = Console.ReadLine();

        for (int a = 0; a < totalProducts; a++)
        {
            if (t_id == productId[a])
            {
                productId[a] = "";
                for (int k = a; k < 20; k++)
                {
                    productId[k] = productId[k + 1];
                    productName[k] = productName[k + 1];
                    price[k] = price[k + 1];
                }

                totalProducts--;
                Console.WriteLine("\n\n *** PRODUCT DELETED SUCCESSFULLY ***");
            }
            found++;
        }

        if (found == 0)
        {
            Console.WriteLine("No match");
        }

        Console.ReadKey();
    }

    // Function to display the worker menu and return the user's choice
    static string DisplayWorkerMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~~\n\n");
        Console.WriteLine("\t***WORKER MENU***\n\n");
        Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~~\n\n\n");

        string workerChoice;
        Console.Write("Enter:      1 Delete Product       2 to view Collection    3 to view Customers Detail    0 to go back ");
        workerChoice = Console.ReadLine();

        return workerChoice;
    }

    // Function to display customer details
    static void CusDetail(string[] userName, string[] userPass, string[] role, int userCount)
    {
        Console.WriteLine("User ID\t\t\tUser Name\t\t\tUser Password\n");

        for (int x = 0; x < userCount; x++)
        {
            if (role[x] == "customer" || role[x] == "Customer")
            {
                Console.WriteLine($"{x + 1}\t\t\t{userName[x]}\t\t\t{userPass[x]}");
            }
        }

        Console.ReadKey();
    }

    // Function to display worker details
    static void WorkerDetail(string[] userName, string[] userPass, string[] role, int userCount)
    {
        int workerCount = 0;
        Console.WriteLine("Worker ID\t\t\tWorker Name\t\t\tWorker Password\n");

        for (int x = 0; x < userCount; x++)
        {
            if (role[x] == "worker" || role[x] == "Worker")
            {
                Console.WriteLine($"{x + 1}\t\t\t{userName[x]}\t\t\t{userPass[x]}");
                workerCount++;
            }
        }

        if (workerCount == 0)
        {
            Console.WriteLine("No worker to display");
        }

        Console.WriteLine($"Total number of Workers: {workerCount}");
        Console.ReadKey();
    }

    // Function to check if the entered code matches the verification code
    static bool OwnerCheck(string inCode, string vCode)
    {
        bool c = false;

        if (inCode == vCode)
        {
            c = true;
        }

        return c;
    }
 // Function to display the admin menu and return the admin's choice
    static string DisplayAdminMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        string adminChoice;

        Console.WriteLine("Enter your choice: ");
        Console.WriteLine("1 to view Collection ");
        Console.WriteLine("2 to delete product ");
        Console.WriteLine("3 to view number of Orders placed ");
        Console.WriteLine("4 to view details of Workers ");
        Console.WriteLine("5 to change admin verification code  ");
        Console.WriteLine("7 to add product  ");
        Console.WriteLine("0 to go back ");
        Console.ReadLine(); // Consuming the newline character left in the buffer
        adminChoice = Console.ReadLine();
        return adminChoice;
    }

    // Function to display the total number of orders placed
    static void OrdersPlaced()
    {
        Console.WriteLine($"The number of orders Placed is: {orderCount}");
        Console.ReadKey();
    }

    // Function to take customer review and save it in an array
    static void CustomerReview(string[] Review, ref int reviewNo, ref int r)
    {
        Console.Write("Enter your review: ");
        Review[r] = Console.ReadLine();
        r++;
        Console.WriteLine("Your review has been submitted. Thank You!");
        Console.ReadKey();
    }

    // Function to change the admin verification code
    static string ChangeVerCode(string vCode)
    {
        string tcode, newCode = "0"; // temporary code for checking
        Console.Write("Enter current Verification code: ");
        tcode = Console.ReadLine();

        if (tcode == vCode)
        {
            Console.Write("Enter New Admin Verification code (at least 5 characters long): ");
            newCode = Console.ReadLine();

            if (newCode.Length > 4)
            {
                vCode = newCode;
                Console.WriteLine("Code updated Successfully\nPress any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid code! \nPress any key to continue");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid");
            Console.ReadKey();
        }

        return vCode;
    }

    // Function to add a new product
    static void AddProduct(ref int totalProducts, string[] productId, string[] productName, string[] price)
    {
        int count = 0;
        string tempProductName, tempPrice;
        Console.Write("Enter Product Name: ");
        tempProductName = Console.ReadLine();
        productName[totalProducts] = tempProductName;

        Console.Write("Enter Product Price: ");
        tempPrice = Console.ReadLine();
        price[totalProducts] = tempPrice;

        totalProducts++;
        Console.WriteLine("\n\tProduct added successfully");
        Console.WriteLine($"\n\tTotal number of products is: {totalProducts}");
        Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();
    }
     // Function to parse data from a line based on a specific field (comma-separated)
    static string ParseData(string line, int field)
    {
        string item = string.Empty;
        int commaCount = 1;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == ',')
            {
                commaCount++;
            }
            else if (field == commaCount)
            {
                item += line[i];
            }
        }

        return item;
    }

    // Function to load user data from a file into arrays
    static void LoadUserData(string[] userName, string[] userPass, string[] role, ref int userCount)
    {
        string line;
        using (StreamReader file = new StreamReader("file.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                string name = ParseData(line, 1);
                string pass = ParseData(line, 2);
                string role1 = ParseData(line, 3);

                userName[userCount] = name;
                userPass[userCount] = pass;
                role[userCount] = role1;
                userCount++;
            }
        }
    }

    // Function to write user data from arrays to a file
    static void WriteData(string[] userName, string[] userPass, string[] role, int userCount)
    {
        using (StreamWriter file = new StreamWriter("file.txt"))
        {
            for (int i = 0; i < userCount; i++)
            {
                file.WriteLine($"{userName[i]},{userPass[i]},{role[i]}");
            }
        }
    }

    // Function to load product data from a file into arrays
    static void LoadProductData(string[] productId, string[] productName, string[] price, ref int totalProducts)
    {
        string line;
        using (StreamReader file = new StreamReader("productData.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                string name = ParseData(line, 1);
                string pric = ParseData(line, 2);

                productName[totalProducts] = name;
                price[totalProducts] = pric;

                totalProducts++;
            }
        }
    }

    // Function to write product data from arrays to a file
    static void WriteProductData(string[] productId, string[] productName, string[] price, int totalProducts)
    {
        using (StreamWriter file = new StreamWriter("productData.txt"))
        {
            for (int i = 0; i < totalProducts; i++)
            {
                file.WriteLine($"{productName[i]},{price[i]},");
            }
        }
    }
//***************************************************   headers start here  ***************************************************
    // Function to print welcome header
    static void WelcomeHeader()
    {
        Console.WriteLine();
        Console.WriteLine("\t\t\t\t\t__        __   _                               _____  ");
        Console.WriteLine("\t\t\t\t\t\\ \\      / /__| | ___ ___  _ __ ___   ___     |_   _|__ ");
        Console.WriteLine("\t\t\t\t\t \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\      | |/ _ \\ ");
        Console.WriteLine("\t\t\t\t\t  \\ V  V /  __/ | (_| (_) | | | | | |  __/      | | (_) |");
        Console.WriteLine("\t\t\t\t\t   \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|      |_|\\___/ ");
        Console.WriteLine();
        Console.WriteLine();
    }

    // Function to print general header
    static void Header()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t  ___    ___   ___  ____  __   __    ___   ____  __  ____  __      ____ __  __ ______ __   ___  ____");
        Console.WriteLine("\t\t\t // \\\\  //    //   ||    (( \\ (( \\  // \\\\  || \\\\ || ||    (( \\    ||    ||\\ || | || | ||  //   ||   ");
        Console.WriteLine("\t\t\t ||=|| ((    ((    ||==   \\\\   \\\\  ((   )) ||_// || ||==   \\\\     ||==  ||\\\\||   ||   || ((    ||== ");
        Console.WriteLine("\t\t\t || ||  \\\\__  \\\\__ ||___ \\_)) \\_))  \\\\_//  || \\\\ || ||___ \\_))    ||___ || \\||   ||   ||  \\\\__ ||___");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ResetColor();
    }

    // Function to print sign up header
    static void SignUpHeader()
    {
        Console.WriteLine(" __ _                                                       ");
        Console.WriteLine("/ _(_) __ _ _ __    /\\ /\\ _ __       /\\/\\   ___ _ __  _   _ ");
        Console.WriteLine("\\ \\| |/ _` | '_ \\  / / \\ \\ '_ \\     /    \\ / _ \\ '_ \\| | | |");
        Console.WriteLine("_\\ \\ | (_| | | | | \\ \\_/ / |_) |   / /\\/\\ \\  __/ | | | |_| |");
        Console.WriteLine("\\__/_|\\__, |_| |_|  \\___/| .__/    \\/    \\/\\___|_| |_|\\__,_|");
        Console.WriteLine("      |___/              |_|         ");
        Console.WriteLine();
        Console.WriteLine();
    }

    // Function to print sign in header
    static void SignInHeader()
    {
        Console.WriteLine(" ___  _             _            __ __                ");
        Console.WriteLine("/ __><_> ___ ._ _  | |._ _      |  \\  \\ ___ ._ _  _ _ ");
        Console.WriteLine("\\__ \\| |/ . || ' | | || ' |     |     |/ ._>| ' || | |");
        Console.WriteLine("<___/|_|\\_. ||_|_| |_||_|_|     |_|_|_|\\___.|_|_|`___|");
        Console.WriteLine("        <___'                                         ");
    }

    // Function to print collection header
    static void CollectionHeader()
    {
        Console.WriteLine("   ____   U  ___ u   _       _     U _____ u   ____   _____             U  ___ u  _   _   ");
        Console.WriteLine("U /\"___|   \\/\"_ \\/  |\"|     |\"|    \\| ___\"|/U \"___| |_ \" _|     ___     \\/\"_ \\/ | \\ |\"|    ");
        Console.WriteLine("\\| | u     | | | |U | | u U | | u   |  _|\"  \\| | u     | |      |_\"_|    | | | |<|  \\| |>   ");
        Console.WriteLine(" | |/__.-,_| |_| | \\| |/__ \\| |/__  | |___   | |/__   /| |\\      | | .-,_| |_| |U| |\\  |u   ");
        Console.WriteLine("  \\____|\\_)-\\___/   |_____| |_____| |_____|   \\____| u |_|U    U/| |\\u\\_)-\\___/  |_| \\_|    ");
        Console.WriteLine(" _// \\      \\     //  \\  //  \\  <<   >>  _// \\  _// \\_.-,_|___|_,-.  \\    ||   \\,-. ");
        Console.WriteLine("(__)(__)    (__)   (_\")(\"_)(_\")(\"_)(__) (__)(__)(__)(__) (__)\\_)-' '-(_/  (__)   (_\")  (_/  ");
    }

    // Function to print glasses
    static void Glasses()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        GotoXY(120, 5); Console.WriteLine("    __         __");
        GotoXY(120, 6); Console.WriteLine("   /.-'       `-.\\" );
        GotoXY(120, 7); Console.WriteLine("  //             \\\\");
        GotoXY(120, 8); Console.WriteLine(" /j_______________j\\");
        GotoXY(120, 9); Console.WriteLine("/o.-==-. .-. .-==-.o\\");
        GotoXY(120, 10); Console.WriteLine("||      )) ((      ||");
        GotoXY(120, 11); Console.WriteLine(" \\\\____//   \\\\____// ");
        GotoXY(120, 12); Console.WriteLine("  `-==-'     `-==-'" );
        Console.ResetColor();
    }

    // Function to print admin header
    static void AdminHeader()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("***ADMIN MENU***");
        Console.WriteLine();
    }

    // Function to print worker detail header
    static void WorkerDetailHeader()
    {
        Console.WriteLine("      __   __        ___  __   __      __   ___ ___             ");
        Console.WriteLine("|  | /  \\ |__) |__/ |__  |__) /__`    |  \\ |__   |   /\\  | |    ");
        Console.WriteLine("|/\\| \\__/ |  \\ |  \\ |___ |  \\ .__/    |__/ |___  |  /~~\\ | |___ ");
        Console.WriteLine();
        Console.WriteLine();
    }


    // Function to set cursor position in the console
    static void GotoXY(int x, int y)
    {
        Console.SetCursorPosition(x, y);
    }
//**************************************        headers end here        ********************************************

    // Function to set product details
    static void ProductDetails(string[] productId, string[] productName, string[] price, ref int totalProducts)
    {
        productName[0] = "Glasses";
        price[0] = "750";
        productName[1] = "Watches";
        price[1] = "230";
        productName[2] = "Rings";
        price[2] = "730";
        productName[3] = "Scarf";
        price[3] = "320";
        productName[4] = "Belts";
        price[4] = "730";
        productId[0] = "1";
        productId[1] = "2";
        productId[2] = "3";
        productId[3] = "4";
        productId[4] = "5";

        totalProducts = 5; // Update totalProducts accordingly
    }

    // Function to convert string to integer
    static int CustomStoi(string str)
    {
        int result = 0;
        bool isNegative = false;
        int i = 0;

        // Handling the sign
        if (str[0] == '-')
        {
            isNegative = true;
            i = 1;
        }

        for (; i < str.Length; ++i)
        {
            if (char.IsDigit(str[i]))
            {
                result = result * 10 + (str[i] - '0');
            }
            else
            {
                // If the character is not a digit, break or handle as required
                break;
            }
        }

        return isNegative ? -result : result;
    }
}
