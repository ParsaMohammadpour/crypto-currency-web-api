# Answers to technical questions

### 1-	How long did you spend on the coding assignment? What would you add to your solution if you had more time? If you didn't spend much time on the coding assignment then use this as an opportunity to explain what you would add.

About the time, I don’t know how much time I had spent on this code assignment exactly, because I had to multitasking due to 2 midterms exam that I have on Sunday and some assignments about university as I had told. But it was only about maybe between 8 and 12 at the top. I wish I had more time to implements other things in this assignment, but I hadn’t.
Things that I would have added to this project are as follows: 

#### adding rate limiter:
I would have added some rate limiter for Api’s that stopped people from sending too much requests.

#### Adding caching policies in order to lower the communication between my service and external service.

#### adding multiple Polly’s policies:
I would have added some other Api’s with same functionality but with different Polly’s policies. (On the extreme version, even adding identity service and activate some of these only for premium users … but this was maybe too much for this project, so let’s, just say adding other Api’s with same functionality and different policies)

#### Quartus and scheduling
One the thing that I would have liked to add to this project is to add scheduling and background jobs. In this case I would have called this external service on regular basis and store the results in cache or database and then only returning responses from database and caches. This can be very helpful in scenarios, specially in case that the price for example changes every minuet and we have many requests in a minuet which return same values. Also lowers response time too.

#### clean architecture:
 writing program with all specified things in clean architecture (when it was big enough, not for the case with few more classes and functionality. For example at the time that I have had implemented all the above features, I would have go with clean architecture)

#### writing more test:
Writing more unit tests and also writing end-to-end tests and in the case of having more code bases (like in the case of having all above features) I would have liked to try writing architecture tests.

#### health check
I would have liked to add application health check and some other things for monitoring (using .net aspire or other things in extreme case). Or some things like dockerize (make a docker-compose file that has cache, our service and other things)

#### logging:
I would have logged better and even with more details.

### 2-	What was the most useful feature that was added to the latest version of your language of choice?

I haven’t get involved too much with the latest version of .net but I have heard in some YouTube channels, LinkedIn posts and websites that there was a lot of improvements in performance and speed (in Linq queries and other things), swagger direct support has been removed and now it supports OpenApi directly instead of swagger. (Also you can add swagger or other things like scalar or … ). But with a little bit of searching and a few hours of reading we could get most of those features. The thing that I have used but wasn’t much, was logging in terminal (which terminal has became the default in this version I think)

### 3-	How would you track down a performance issue in production? Have you ever had to do this?

I would have tracked down a request. Where does it go. See what happens step by step. Use logging and gather information about that problem. Seeing and think of the path that this issue has and the important sections that it has. Estimating the time of each part in the production (due to high amount of data and other things some things might only happen in production and they won’t happen in local or testing environments). Asking others about the problem. Trying to improve the algorithm or using some data structure if it helps. Like hash dictionaries and … . searching and asking about query optimization. Checking disposable object to be disposed correctly. Do some actions in database when we don’t need to bring data (or all data) from database. Writing procedure in database and run them. Writing some of the job that gets considerable resource in background with background jobs or events. If the code is not so much, rewrite them if there is other way for that implementation and is better and if we have time and it is possible and many other things that doesn’t come to my mind right now.
Yes I have done these things in my previous work experiences.

### 4-	What was the latest technical book you have read or tech conference you have been to? What did you learn?

I search too much and read books, most of the books that I read are related to university and my major which is Algorithms and Computation. Some of the books that I have been studying are books about algorithms like CLRS, Goodrich, Introduction to Theoretical computer science or Nancy Lynch book about distributed systems. About c# and .net I usually follow the news and follow youtubers and some websites. I watch their videos and if I find something interesting I would go for it and search for it. I also have attended one or two conference. (without counting NDC conference of Microsoft YouTube channel)

### 5-	What do you think about this technical assessment?

This assessment contained many good things like asking to go and search for those Api’s documentations and get things on my own instead of just simply getting me the documentation. You can see how do I deal with these. On other good thing was the first question and asking what would I do if had more time and give some ideas for the continuation of this task. The third question was good. You can see how people react in these moments and how they think. The fourth question was the best. I personally regard too much respect for those who read books especially because they are usually always in favor of learning and improving and they want to grow. The second question was good but not as much as other questions. (I don’t mean to disrespect at all and I hope you may forgive me for this) but this question are goods when you want to is someone eager and enthusiast about some thing and if they have passion for being in the technology edge or not, but these questions can be answered by a simple search.

### 6-	Please, describe yourself using JSON.
JsonSerializationException ;)
```
{
    "name": "Parsa Mohammadpour",
    "birth-date": "2001-9-16",
    "education": {
        "bachelor": {
            "completed": true,
            "university": "Shahid Beheshti",
            "major": "Computer engineering"
        },
        "master": {
            "completed": false,
            "university": "Tehran",
            "major": "Algorithm and Computations"
        }
    },
    "work-experiences": [
        {
            "company": "Hasin",
            "index": 1
        },
        {
            "company": "IranAirTourAirline",
            "index": 2
        }
    ],
    "soft-skills": {
        "is-hardwork": true,
        "like-team-working": true,
        "like-problem-solving": true,
        "like-new-experiment": true
    }
}
```

<br/>
<br/>

At the end, I wanted to apologize one more time that I couldn't spent much more time for this assignment due to two midterm exam that I have on sunday morning, and I hope you may forgive me for the quality of the code and other things. I am sorry for that and I hope you may forgive me for that.

Thanks.
