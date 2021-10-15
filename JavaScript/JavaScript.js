function Catalogue() {

    const [products, setProducts] = useState([])
    const [token, removeToken] = useCookies(['mytoken'])
    let history = useHistory()


    useEffect(() => {
        fetch('https://greenhouse-api-django.herokuapp.com/products/list/', {
            'method': 'GET',
            headers: {
                "Content-Type": "application/json",
            }
        })
            .then(response => response.json())
            .then(response => setProducts(response))
            .catch(error => console.log(error))
    }, [])

    useEffect(() => {
        if (!token['mytoken']) {
            history.push('/signin/')
        }
    }, [token])

    const

}

function App() {
    return (
        new Date().getFullYear()
        )
}

let URLS = {
    django_url: 'https://greenhouse-api-django.herokuapp.com',
    arduino_url: 'https://greenhouse-iot-api.herokuapp.com'
}

class UserSession {
    static instance = new UserSession()

    login = async body => {
        try {
            let request = await fetch(`${URLS.django_url}/users/login/`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json'
                },
                body: JSON.stringify(body),
            })
            let response = await request.json()
            try {
                let key = `token-${reponse.n}`
            }

            })
        }
    }
}