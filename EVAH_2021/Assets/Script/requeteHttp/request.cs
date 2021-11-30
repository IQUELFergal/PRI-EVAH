using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;
using System.Web;

using System.Xml.Linq;

using Newtonsoft.Json.Linq;
using System;
using System.Text;
using TMPro;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    public TextMeshPro textAlertsToDo;
    public TextMeshPro textAlertsDone;

    private readonly string url = "https://sequoia-labo.emanrisk.lan/";
    private bool request_send = false;
    private bool request_decrypt = false;  
    private string tokens = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyaWQiOjE1MywidXNlcm5hbWUiOiJrbGViYXJzIiwiaW5zdGFuY2VpZCI6MzB9.NzM3YjViZjdhNzVhMzc3ZWEyZGNiZmM1Y2NjMmE0YWE1YzM1YmFjYWM1OTY3ZjFlZTc4ZjUwZTRkNDAzYTU2NQ";
    private bool touched = false;
    private bool endRequest = false;

    public bool doRequest = false;


    private List<Product> products = new List<Product>();
    private List<Tool> tools = new List<Tool>();

    private ProductType productType;
    private Operator ope;
    private Activity act;
    private Visual visual;
    private Task task;
    private ActivityTask actTask;
    private Alerts alert;

    private Product productControl; 

    private Dictionary<int, ToolType> toolTypes = new Dictionary<int, ToolType>();
    private Dictionary<int, ProductType> productsType = new Dictionary<int, ProductType>();
    private Dictionary<int, Operator> operators = new Dictionary<int, Operator>();
    private Dictionary<int, Activity> activities = new Dictionary<int, Activity>();
    private Dictionary<int, Task> tasks = new Dictionary<int, Task>();
    private Dictionary<int, ActivityTask> activitiesTasks = new Dictionary<int, ActivityTask>();
    //private Dictionary<int, Alerts> alerts = new Dictionary<int, Alerts>();
    private List<Alerts> alerts = new List<Alerts>();
    private List<Etape> scenario = new List<Etape>(); 

    
    private bool modifetape = false;
    int i = 0;

    private GameObject image_scenar;
    private TextMeshProUGUI text_scenar;
    private GameObject etiquette;

    private int idcontrol;

    private Dictionary<string, bool> stopCondition = new Dictionary<string, bool>(); 

    private bool timefinish = false;
    private bool timestart = false;
    private bool nextStep = false;

    private bool etiquettecheck = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Console.Write(doRequest);

        scenario = MakeScenarxml();
        image_scenar = GameObject.Find("RawImage_scenar");
        text_scenar = GameObject.Find("Text_scenar").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Input.GetKeyUp(KeyCode.P))) StartCoroutine(GetPing());
        //if ((Input.GetKeyUp(KeyCode.L))) StartCoroutine(PostLogin_check());



        // requete http pour recuperer les données
        if (doRequest)
        {
            if (i == 0)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetPing());
                    request_send = true;
                }

                if (request_decrypt)
                {
                    request_send = false;
                    i = 1;
                }
            }
            else if (i == 1)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(PostLogin_check());
                    request_send = true;
                }

                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 2)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(PostInstance_switch(30));
                    request_send = true;
                }

                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 3)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetMetaData());
                    request_send = true;
                }

                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 4)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    //products = MakeProducts();
                    products = MakeProductsxml();
                    toolTypes = MakeToolTypeXml();
                    //tools = MakeTool();
                    tools = MakeToolXml();
                    StartCoroutine(GetOperators());
                    request_send = true;
                }

                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 5)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetActivities());
                    request_send = true;
                }

                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 6)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetTasks());
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 7)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetActivityTasks());
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 8)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    //StartCoroutine(PostControl());
                    request_decrypt = true; //a enlever quand post control est actif
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 9)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetControls());
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 10)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetControlId(4));
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i++;
                }
            }
            else if (i == 11)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetScreen());
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i++;


                }
            }

            else if (i == 12)
            {
                if (!request_send)
                {
                    print("getAlerts");
                    request_decrypt = false;
                    StartCoroutine(GetAlerts());
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    DisplayAlerts();
                    DisplayProductAlert();
                    //MakeProductsxml();
                    i++;
                    endRequest = true;
                }
            }
            
            else if(i == 13)
            {
               
                if (!request_send)
                {
                    request_decrypt = false;
                    if (Input.GetKeyUp(KeyCode.C))
                    {
                        if (productControl != null)
                        {
                            StartCoroutine(PostControl(alerts[0].activityTask.id, productControl));
                            Debug.Log(alerts[0].activityTask.id);
                            request_send = true;
                            //productControl.controlDone = false;
                            productControl = null;
                        }
                        else
                        {
                            print("il faut faire le control avant");
                        }
                        
                        
                    }
                    if (Input.GetKeyUp(KeyCode.V))
                    {
                        StartCoroutine(PostControl(alerts[0].activityTask.id,products[2]));
                        Debug.Log(alerts[0].activityTask.id);
                        request_send = true;
                    }
                }
                if (request_decrypt)
                {

                    request_send = false;
                    alerts[0].done = 1;
                    DisplayAlerts();
                    //DisplayProductAlert();
                    i++;
                }
            }
            else if (i == 14)
            {
                if (!request_send)
                {
                    request_decrypt = false;
                    StartCoroutine(GetControlId(idcontrol));
                    request_send = true;
                }
                if (request_decrypt)
                {
                    request_send = false;
                    i=12;
                    
                    

                }
            }

            


        }

        //affichage thermomètre + condition controle
        for (int j = 0; j < products.Count; j++)
        {
            GameObject go = GameObject.Find(products[j].gameObject.name + "/touched");
            if (go != null)
            {
                
                if (go.tag == "touche" && !touched && endRequest)
                {
                    Debug.Log("touche à true dans request");
                    touched = true;
                    foreach (var p in alerts[0].activity.products)
                    {   /*
                        TextMeshProUGUI textThermo = GameObject.Find("Thermomètre/Scaler/Body/Ecran/Image/Text (TMP)").GetComponent<TextMeshProUGUI>();
                        if (textThermo)
                        {
                            textThermo.text = products[j].gameObject.GetComponent<Food>().Temperature.ToString() + "°C";
                            print(products[j].gameObject.GetComponent<Food>().Temperature.ToString() + "°C");
                        }
                        */
                        if (p.label == products[j].productType.label)
                        {
                            //products[j].controlDone = true;
                            print("label = name");
                            productControl = products[j];

                        }
                    }
                }

                if (go.tag == "Untagged" && touched && endRequest)
                {
                    Debug.Log("touche à false dans request");
                    touched = false;
                }
            }
            else
            {
                print("go est nul");
            }
        }

        //scenario
        
        if (!modifetape)
        {
            
            if (scenario[0].texture)
            {
                image_scenar.SetActive(true);
                image_scenar.GetComponent<RawImage>().texture = scenario[0].texture;
            } // on affiche l'image pour le scénario si elle existe dans l'étape
            else
            {
                image_scenar.SetActive(false);
            }

            if (scenario[0].objet)
            {
                if (scenario[0].objet.GetComponent<Outline>())
                {
                    scenario[0].objet.GetComponent<Outline>().enabled = true;
                }
            } //on met en surbrillance l'objet voulu 

            if ((scenario[0].arret.temps != 0) && !timestart)
            {
                StartCoroutine(Wait(scenario[0].arret.temps));
                timestart = true;
            }
            

            if (text_scenar)
            {
                text_scenar.text = scenario[0].instruction;
                print(scenario[0].instruction);
            }//on affiche l'instruction

            modifetape = true;
        }
        if ((scenario[0].arret.temps != 0) && timestart)
        {
            if (timefinish)
            {
                nextStep = true;
                timestart = false;
                timefinish = false;
            }

        }
        if ((Input.GetKeyUp(KeyCode.S)))
        {
            nextStep = true;
        } // passer à l'étape suivant s'il y a un bug

        if (scenario[0].arret.evenementobjet)
        {
            if (scenario[0].arret.evenementobjet.GetComponent<StopCondition>())
            {
                if (scenario[0].arret.evenementobjet.GetComponent<StopCondition>().isStopCondition)
                {
                    print("la condition est a true");
                    nextStep = true;
                    scenario[0].arret.evenementobjet.GetComponent<StopCondition>().isStopCondition = false;

                }

            }
        }
        if (nextStep)
        {
            print("nextstep true");
            nextStep = false;
            if (scenario[0].objet)
            {
                if (scenario[0].objet.GetComponent<Outline>())
                {
                    scenario[0].objet.GetComponent<Outline>().enabled = false;
                }
            }
            scenario.RemoveAt(0);
            modifetape = false;
        }

        etiquette = GameObject.Find("Chicken/Etiquette");
        if (etiquette && !etiquettecheck)
        {
            etiquette.GetComponentsInChildren<TextMeshPro>()[0].text = products[2].name + "  "+ products[2].gameObject.GetComponent<Food>().Temperature +"°C  "+ DateTime.Now;
            etiquettecheck = true;
        }// affichage sur l'étiquette de l'heure et du produit (pour l'instant juste le poulet)
    }

    private IEnumerator Wait(int waitTime)
    {
        print("debut de wait");
        yield return new WaitForSeconds(waitTime);
        timefinish = true;
        print("fin de wait");
    }


    public List<Etape> MakeScenarxml()
    {
        string mappingPath = Application.dataPath + "/StreamingAssets/scenario.xml";
        string textXML = System.IO.File.ReadAllText(mappingPath);
        XDocument parser = XDocument.Parse(textXML);

        XElement root = parser.Root;


        XElement productsElement = root.Element("Etapes");
        List<Etape> etapes = new List<Etape>();
        Etape e;

        foreach (XElement child in productsElement.Elements())
        {
            e = new Etape();

            e.id = int.Parse(child.Attribute("id").Value);

            print(child.Attribute("id").Value);

            foreach (XElement child2 in child.Elements())
            {
                if (child2.Name.LocalName == "Instruction")
                {
                    e.instruction = child2.Value;

                }
                if (child2.Name.LocalName == "Ressources")
                {
                    if(!File.Exists("images/" + child2.Value))
                    {
                        e.texture = Resources.Load("images/" + child2.Value) as Texture2D;
                        print(e.texture);
                    }

                }
                if (child2.Name.LocalName == "Objet")
                {
                    e.objet = GameObject.Find(child2.Value);
                }
                foreach(XElement child3 in child2.Elements())
                {
                    print(child3.Name.LocalName);
                    if(child3.Name.LocalName == "Temps")
                    {
                        e.arret.temps = int.Parse(child3.Value);
                    }

                    if (child3.Name.LocalName == "Evenement")
                    {
                        //e.arret.evenementobjet = child3.Value;
                        e.arret.evenementobjet = GameObject.Find(child3.Value);
                        print(e.arret.evenementobjet);
                        
                    }
                }
            }
            etapes.Add(e);
        }

        return etapes;
    }

    public List<Product> MakeProductsxml()
    {
        string mappingPath = Application.dataPath + "/StreamingAssets/products.xml";
        string textXML = System.IO.File.ReadAllText(mappingPath);
        XDocument parser = XDocument.Parse(textXML);

        XElement root = parser.Root;

        
        XElement productsElement = root.Element("Products");
        List<Product> products = new List<Product>();
        Product p;

        foreach (XElement child in productsElement.Elements())
        {
            p = new Product();

            p.id = int.Parse(child.Attribute("id").Value);
            p.name = child.Attribute("name").Value;
            p.productType = productsType[int.Parse(child.Attribute("productType").Value)];
            
            print(child.Attribute("id").Value);
            
            foreach (XElement child2 in child.Elements())
            {
                if (child2.Name.LocalName == "temperature")
                {
                    //p.temperature = int.Parse(child2.Value);

                }
                if (child2.Name.LocalName == "bacteries")
                {
                    p.bacteries = bool.Parse(child2.Value);
                }
                if (child2.Name.LocalName == "gameObject")
                {
                    p.gameObject = GameObject.Find(child2.Value);
                }
            }
            p.temperature = p.gameObject.GetComponent<Food>().Temperature;
            p.MakeText();
            //GameObject.Find(p.gameObject.name + "/Text").GetComponent<TextMeshPro>().text = p.text;
            print(p.gameObject.name + "/Text");
            GameObject go = GameObject.Find(p.gameObject.name + "/Text");
            if (go)
            {
                print("found");
                go.GetComponent<TextMeshPro>().text = p.text;
                go.SetActive(false);
            }
            products.Add(p);
        }

        return products;
    }

    public Dictionary<int,ToolType> MakeToolTypeXml()
    {
        Dictionary<int, ToolType> tooltypes = new Dictionary<int, ToolType>();

        string mappingPath = Application.dataPath + "/StreamingAssets/toolType.xml";
        string textXML = System.IO.File.ReadAllText(mappingPath);
        XDocument parser = XDocument.Parse(textXML);

        XElement root = parser.Root;


        XElement toolTypesElement = root.Element("ToolTypes");
        ToolType toolType;

        foreach (XElement child in toolTypesElement.Elements())
        {
            toolType = new ToolType();
            toolType.id = int.Parse(child.Attribute("id").Value);
            toolType.label = child.Attribute("label").Value;
            print(toolType.id);
            tooltypes.Add(toolType.id, toolType);
        }


        return tooltypes;
    }

    public List<Tool> MakeToolXml()
    {
        List<Tool> tools = new List<Tool>();

        string mappingPath = Application.dataPath + "/StreamingAssets/tools.xml";
        string textXML = System.IO.File.ReadAllText(mappingPath);
        XDocument parser = XDocument.Parse(textXML);

        XElement root = parser.Root;


        XElement toolsElement = root.Element("Tools");
        Tool tool;

        foreach (XElement child in toolsElement.Elements())
        {
            tool = new Tool();
            tool.id = int.Parse(child.Attribute("id").Value);
            tool.name = child.Attribute("name").Value;
            print(int.Parse(child.Attribute("toolType").Value));
            tool.toolType = toolTypes[int.Parse(child.Attribute("toolType").Value)];
            //print(toolTypes[401]);
            foreach(XElement child2 in child.Elements())
            {
                if (child2.Name.LocalName == "gameObject")
                {
                    tool.gameObject = GameObject.Find(child2.Value);
                }
            }
            print(tool.name);
            tools.Add(tool);
        }

        return tools;
    }

    public List<Tool> MakeTool()//version pas utilisée
    {
        List<Tool> tools = new List<Tool>();

        ToolType sonde = new ToolType(1, "Sonde");
        Tool sonde1 = new Tool(1, "sonde1", sonde);

        sonde1.gameObject = GameObject.Find("Sonde");
        tools.Add(sonde1);

        return tools;
    }
     

    public void DisplayAlerts() //affichage des alertes sur le mur 
    {
        print("display alerts");
        textAlertsToDo.text = " Control à faire : ";
        for (int i = 0; i < alerts.Count; i++)
        {
            
            if (alerts[i].done == 0)
            {
                textAlertsToDo.text += "\n id : " + alerts[i].id + "\n activityTask id : " + alerts[i].activityTask.id + "\n activity : " + alerts[i].activity.visual.name + "\n task : " + alerts[i].activityTask.task.visual.name + "\n last control : " + alerts[i].lastControl;
                textAlertsToDo.color = new Color(255, 255, 255);
                
            }

        }
        for (int i = 0; i < alerts.Count; i++)
        {
            if (alerts[i].done == 1)
            {
                textAlertsDone.text += "\n id : " + alerts[i].id + "\n activityTask id : " + alerts[i].activityTask.id;
                textAlertsDone.color = new Color(0, 255, 0);
            }

        }
        

    }

    public void DisplayProductAlert() //affichage des produits concernés par les alerts 
    {
        
        print("affichage outline");
        foreach (var p in alerts[0].activity.products)
        {
               
            foreach (var p2 in products)
            {
                if (p.id == p2.productType.id)
                {
                    Debug.Log(p2.name);
                    p2.gameObject.GetComponent<Outline>().enabled = true;
                    p2.isColored = true;
                    Debug.Log("id pareil");
                }
                else if (p.id != p2.productType.id && !p2.isColored)
                {
                    
                    p2.gameObject.GetComponent<Outline>().enabled = false;
                    Debug.Log("id pas pareil");
                }
            }
        }
        if(alerts[0].activity.products.Count == 0)
        {
            foreach (Product p in products)
            {
                p.gameObject.GetComponent<Outline>().enabled = false;
            }
        }

        foreach (var p in products)
        {
            p.isColored = false;
        }

    }


    IEnumerator GetScreen()
    {

        Debug.Log("getScreen");
        UnityWebRequest www = UnityWebRequest.Get("http://127.0.0.1:3333/navigate?url=p/activities"); //méthode Get avec l'url voulue
        

        


        yield return www.SendWebRequest(); //envoie de la requête
        if (www.isNetworkError || www.isHttpError) // on regarde s'il y a une erreur 
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error); // on affiche l'erreur
            request_decrypt = true;
        }
        else
        {

            Debug.Log(www.downloadHandler.text); // on affiche la réponse
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            DisplayScreen screen = new DisplayScreen();
            screen = JsonConvert.DeserializeObject<DisplayScreen>(response);

            char[] separator = { ',', '"' };
            String[] strlist = screen.image.Split(separator, StringSplitOptions.RemoveEmptyEntries); // on slip la chaine pour récuperer seulement le code de l'image en base 64

            byte[] imageBytes = Convert.FromBase64String(strlist[1]); // on le converti en byte et on le met dans une texture
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imageBytes);
            GameObject imageScreen = GameObject.Find("tabletteScreen");
            imageScreen.GetComponent<RawImage>().texture = tex;

            request_decrypt = true;
            
        }

    }

    //requetes http

    IEnumerator GetPing()
    {

        Debug.Log("getPing");
        UnityWebRequest www = UnityWebRequest.Get(url + "ping"); //méthode Get avec l'url voulue
        www.SetRequestHeader("Content-type", "application/json");  //Header de la requête

        www.certificateHandler = new WebRequestCert(); //certificat de validation (-k sur curl) 


        yield return www.SendWebRequest(); //envoie de la requête
        if (www.isNetworkError || www.isHttpError) // on regarde s'il y a une erreur 
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error); // on affiche l'erreur
            request_decrypt = true;
        }
        else
        {

            Debug.Log(www.downloadHandler.text); // on affiche la réponse
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ResponsePing reponse = new ResponsePing();
            reponse.data = new PingAPI();
            reponse = JsonConvert.DeserializeObject<ResponsePing>(response);
            Debug.Log(reponse.data.version);
            request_decrypt = true;
        }

    }
    IEnumerator GetMetaData()
    {

        Debug.Log("getMetaData");
        UnityWebRequest www = UnityWebRequest.Get(url + "metadata");

        www.certificateHandler = new WebRequestCert();
        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {

            string jsonContent = www.downloadHandler.text;
            Debug.Log(www.downloadHandler.text);
            JObject o = JObject.Parse(jsonContent);
            //Debug.Log(o.SelectToken("data.temperatures.prod_temp.101.label"));
            
            for (int i = 0; i < 22; i++) //a modif pour pas avoir le 22
            {
                productType = new ProductType();
                productType.id = (int)o.SelectToken("data.temperatures.prod_temp." + (i + 101).ToString() + ".id");
                productType.label = o.SelectToken("data.temperatures.prod_temp."+(i + 101).ToString()+".label").ToString();
                if (o.SelectToken("data.temperatures.prod_temp." + (i+101).ToString() + ".value.min") != null)
                {
                    productType.temperatureMin = (float)o.SelectToken("data.temperatures.prod_temp." + (i+101).ToString() + ".value.min");
                }
                if (o.SelectToken("data.temperatures.prod_temp." + (i+101).ToString() + ".value.max") != null)
                {
                    productType.temperatureMax = (float)o.SelectToken("data.temperatures.prod_temp." + (i+101).ToString() + ".value.max");
                }
                //Debug.Log(product.ToString());
                productsType.Add(productType.id, productType);
            }  
            request_decrypt = true;
            foreach (var p in productsType)
            {
                Debug.Log(p.ToString());
            }
        }

    }
    IEnumerator PostLogin_check()
    {
        Debug.Log("PostLogin_check");

        Authentification auth1 = new Authentification();
        auth1.username = "klebars";
        auth1.password = "g1Aa47fi";
        string rep = JsonConvert.SerializeObject(auth1);


        UnityWebRequest www = UnityWebRequest.Put(url+ "login_check", rep);

        www.certificateHandler = new WebRequestCert();


        www.SetRequestHeader("Content-type", "application/json");
        www.method = UnityWebRequest.kHttpVerbPOST;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ReponseAuth reponse = JsonConvert.DeserializeObject<ReponseAuth>(response);
            Debug.Log(reponse.data.token);
            //tokens = reponse.data.token;
            request_decrypt = true;

        }
    }
    IEnumerator PostInstance_switch(int instance_id) // ne fonctionne pas
    {
        Debug.Log("PostInstance_switch");
        InstanceSwitch instanceSwitch = new InstanceSwitch();
        instanceSwitch.instance_id = instance_id;
        string rep = JsonConvert.SerializeObject(instanceSwitch );
        UnityWebRequest www = UnityWebRequest.Post(url+"instance_switch", rep);
        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("Content-Type", "application/json");
        //www.method = UnityWebRequest.kHttpVerbPOST;
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetOperatorId(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "operator/" + id.ToString());

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetOperatorIdActicity(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "operator/" + id.ToString()+ "/activities");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text

            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetOperators()
    {
        Debug.Log("getOperators");
        UnityWebRequest www = UnityWebRequest.Get(url + "operators");


        www.certificateHandler = new WebRequestCert();

        //www.SetRequestHeader("Content-type", "application/json");
        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ResponseOperatorAPI reponse = new ResponseOperatorAPI();
            //reponse.data = new OperatorAPI();
            reponse = JsonConvert.DeserializeObject<ResponseOperatorAPI>(response);
            Debug.Log(reponse.data.Length);
            for (int i = 0; i < reponse.data.Length; i++)
            {

                ope = new Operator(reponse.data[i].id, reponse.data[i].name, reponse.data[i].forename);
                operators.Add(ope.id, ope);
            }
            foreach (var op in operators)
            {
              //Debug.Log(op.ToString());
            }


            request_decrypt = true;
        }
    }
    IEnumerator GetActivities()
    {
        Debug.Log("getActivities");
        UnityWebRequest www = UnityWebRequest.Get(url + "activities");

        www.certificateHandler = new WebRequestCert();
        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ResponseActivityAPI reponse = new ResponseActivityAPI();
            reponse = JsonConvert.DeserializeObject<ResponseActivityAPI>(response);
            Debug.Log(reponse.data.Length);
            List<ProductType> listproducts = new List<ProductType>();
            for (int i = 0; i < reponse.data.Length; i++)
            {
                visual = new Visual(reponse.data[i].name, reponse.data[i].icon);
                listproducts = new List<ProductType>();
                if (reponse.data[i].products != null)
                {
                    char[] separators = new char[] { ',', '[', ']' };
                    string[] subs = reponse.data[i].products.Split(separators, StringSplitOptions.RemoveEmptyEntries);


                    for (int j = 0; j < subs.Length; j++)
                    {
                        //int tmp = int.Parse(subs[j]);
                        listproducts.Add(productsType[int.Parse(subs[j])]);
                        //Debug.Log("id à avoir = " +reponse.data[i].products[j]);
                    }
                }

                Debug.Log(reponse.data[i].products);
                act = new Activity(reponse.data[i].id, reponse.data[i].ordering,visual,listproducts);
                activities.Add(act.id, act);
            }
            foreach (var act in activities)
            {
                Debug.Log(act.ToString());
            }
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityId(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "activity/" + id.ToString());

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityIdActivitytask(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "activity/" + id.ToString() + "/activitytasks");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityIdTask(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "activity/" +id.ToString() +"/tasks");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityIdControls(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "activity/" + id.ToString() + "/controls");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityIdAlerts(int id)
    {

        UnityWebRequest www = UnityWebRequest.Get(url + "activity/" + id.ToString() + "/alerts");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetTasks()
    {
        Debug.Log("getTasks");
        UnityWebRequest www = UnityWebRequest.Get(url + "tasks");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ResponseTaskAPI reponse = new ResponseTaskAPI();
            reponse = JsonConvert.DeserializeObject<ResponseTaskAPI>(response);
            Debug.Log(reponse.data.Length);
            Form form = new Form();
            
            for (int i = 0; i < reponse.data.Length   ; i++)
            {
                visual = new Visual(reponse.data[i].name, reponse.data[i].icon);
                form = new Form(reponse.data[i].form);
                task = new Task(reponse.data[i].id, reponse.data[i].type, visual, reponse.data[i].description, form);
                tasks.Add(task.id, task);
            }
            foreach (var task in tasks)
            {
                Debug.Log(task.ToString());
            }
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityTasks()
    {
        Debug.Log("getActivityTasks");
        UnityWebRequest www = UnityWebRequest.Get(url + "activitytasks");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ResponseActivityTaskAPI reponse = new ResponseActivityTaskAPI();
            reponse = JsonConvert.DeserializeObject<ResponseActivityTaskAPI>(response);
            Debug.Log(reponse.data.Length);
            
            for (int i = 0; i < reponse.data.Length; i++)
            {
                
                actTask = new ActivityTask(reponse.data[i].id, reponse.data[i].frequency, reponse.data[i].date_start , reponse.data[i].date_end, activities[reponse.data[i].activity_id], tasks[reponse.data[i].task_id] , reponse.data[i].target_id, reponse.data[i].target);
                activitiesTasks.Add(actTask.id, actTask);
            }
            foreach (var acttask in activitiesTasks)
            {
                Debug.Log(acttask.ToString());
            }
            request_decrypt = true;
        }
    }
    IEnumerator GetActivityTasksId(int id)
    {
          
        UnityWebRequest www = UnityWebRequest.Get(url + "activitytask/" + id.ToString());

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator PostControl(int id_activitiesTask, Product product)
    {
        Debug.Log("postcontrol");

        ControlAPI control1 = new ControlAPI();
        control1.uid = "01234567";
        control1.date_created = "2021-04-27 10:10:10";
        control1.activitytask_id = id_activitiesTask ;
        control1.date_control = "2021-06-03 10:00:00";
        control1.comment = "Lorem ipsum dolor sit amet ...";
        control1.author = "TEST API";
        FormValueAPI valueform1 = new FormValueAPI();
        FormValueAPI valueform2 = new FormValueAPI();
        FormValueAPI valueform3 = new FormValueAPI();

        valueform1.uid = "57b352ebe3121fed";
        valueform1.value = product.temperature.ToString();
        valueform1.metadata.id = product.productType.id.ToString();
        valueform1.metadata.label = product.productType.label.ToString();
        valueform1.metadata.value.min = product.productType.temperatureMin.ToString();
        valueform1.metadata.value.max = product.productType.temperatureMax.ToString();

        valueform2.uid = "7249672e90c84455";
        valueform2.value = "8";

        valueform3.uid = "b08a2bed0998dfb2";
        valueform3.value = "yes";

        List<FormValueAPI> listform = new List<FormValueAPI>();
        listform.Add(valueform1);
        listform.Add(valueform2);
        listform.Add(valueform3);

        control1.form_value = listform;

        string rep = JsonConvert.SerializeObject(control1);

        //string rep2 = "{\"uid\":\"01234567\",\"date_created\":\"2021-04-15 10:10:10\",\"activitytask_id\":281,\"date_control\":\"2021-04-15 10:00:00\",\"conformity\":\"0\",\"form_value\":[{\"uid\":\"57b352ebe3121fed\",\"value\":\"5\",\"metadata\":{\"id\":\"101\",\"label\":\"test\",\"value\":{\"min\":\"10\",\"max\":\"20\"}}},{\"uid\":\"7249672e90c84455\",\"value\":\"8\"},{\"uid\":\"b08a2bed0998dfb2\",\"value\":\"yes\"}],\"comment\":\"Lorem ipsum dolor sit amet ...\",\"author\":\"TEST API\"}";

        UnityWebRequest www = UnityWebRequest.Post(url + "control?XDEBUG_SESSION_START=PHPSTORM", rep );

        www.certificateHandler = new WebRequestCert();
        byte[] bodyRaw = Encoding.UTF8.GetBytes(rep);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        www.SetRequestHeader("Content-Type", "application/json");

        

        //www.method = UnityWebRequest.kHttpVerbPOST;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            
            ResponseControlAPIPost reponse = JsonConvert.DeserializeObject<ResponseControlAPIPost>(response);
            idcontrol = int.Parse(reponse.data.id);
            request_decrypt = true;
        }
    }
    IEnumerator GetControls()
    {
        Debug.Log("GetControl");
        UnityWebRequest www = UnityWebRequest.Get(url + "controls");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;
        }
    }
    IEnumerator GetControlId(int id)
    {
        Debug.Log("GetControlid");
        UnityWebRequest www = UnityWebRequest.Get(url + "control/" + id.ToString());

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            request_decrypt = true;

        }
    }
    IEnumerator GetAlerts()
    {

        UnityWebRequest www = UnityWebRequest.Get(url + "alerts");

        www.certificateHandler = new WebRequestCert();

        www.SetRequestHeader("Authorization", "Bearer " + tokens);
        www.SetRequestHeader("Accept", "application/json");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("  ----> ERREUR !");
            Debug.Log(www.error);
            request_decrypt = true;
        }
        else
        {
            // Show results as text
            Debug.Log("  ----> SUCCES !");
            Debug.Log(www.downloadHandler.text);
            //String jsonString = File.ReadAllText("D:/jsonAlert.json");
            string response = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            ResponseAlertsAPI reponse = new ResponseAlertsAPI();
            reponse = JsonConvert.DeserializeObject<ResponseAlertsAPI>(response);
            //reponse = JsonConvert.DeserializeObject<ResponseAlertsAPI>(jsonString);

            //Debug.Log(reponse.data.Length);
            int id_alerts = 0;
            alerts = new List<Alerts>();
            for (int i = 0; i < reponse.data.Length; i++)
            {
                
                alert = new Alerts(id_alerts, activities[reponse.data[i].activity_id], activitiesTasks[reponse.data[i].activitytask_id], reponse.data[i].last_ctrl, reponse.data[i].done);
                alerts.Add(alert);
                id_alerts++;
            }
            foreach (var alert in alerts)
            {
                Debug.Log(alert.ToString());
            }
            request_decrypt = true;
        }
    }

}


public class WebRequestCert : UnityEngine.Networking.CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        //return base.ValidateCertificate(certificateData);
        return true;
    }
}
